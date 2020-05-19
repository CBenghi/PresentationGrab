using Accord.Imaging;
using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationGrab.ImageProcessing
{
    class PointerDetector
    {
        readonly HSLFiltering findCursor;
        readonly BlobCounterBase bc;

        internal PointerDetector()
        {
            findCursor = new HSLFiltering
            {
                Hue = new Accord.IntRange(359, 2),
                Saturation = new Accord.Range(0.4f, 1),
                Luminance = new Accord.Range(0.25f, 0.60f)
            };
            // findCursor.Hue.

            bc = new BlobCounter
            {
                // set filtering options
                FilterBlobs = true,
                MinWidth = 6,
                MinHeight = 6
            };
        }

        internal bool HasPointer(Bitmap r, out Accord.Point point)
        {

            // Clipboard.SetImage(r);
           
            var outB = findCursor.Apply(r);
            // Clipboard.SetImage(outB);

            bc.ProcessImage(outB);
            Blob[] blobs = bc.GetObjectsInformation();

            if (blobs.Length < 1)
            {
                // System.Diagnostics.Debug.WriteLine("no blobs");
                point = new Accord.Point();
                return false;
            }

            if (blobs.Length == 1 && blobs[0].Area > 45 && blobs[0].Area < 70)
            {
                // System.Diagnostics.Debug.WriteLine("gotten single");
                point = blobs[0].CenterOfGravity.Round();
                return true;
            }

            var toLookAt = blobs.OrderBy(x => SortMostLikelyCursor(x));
            foreach (var blobToLook in toLookAt)
            {


                bc.ExtractBlobsImage(r, blobToLook, false);
                // Clipboard.SetImage(blobToLook.Image.ToManagedImage());


                // if ratio is weird look at next
                // 
                var ratio = blobToLook.Rectangle.Width > blobToLook.Rectangle.Height
                    ? (blobToLook.Rectangle.Width + 0.0) / (blobToLook.Rectangle.Height)
                    : (blobToLook.Rectangle.Height + 0.0) / (blobToLook.Rectangle.Width);

                if (ratio > 3)
                {
                    System.Diagnostics.Debug.WriteLine("skipped ratio");
                    continue;
                }

                var active = blobToLook.Image.CollectActivePixels();
                var centerPoint = blobToLook.CenterOfGravity.Round();
                Accord.IntPoint CenterInImage = new Accord.IntPoint(
                    centerPoint.X - blobToLook.Rectangle.X,
                    centerPoint.Y - blobToLook.Rectangle.Y
                    );

                if (!active.Contains(CenterInImage))
                {
                    // found black in the center... i'll say it's ok
                    point = blobToLook.CenterOfGravity.Round();
                    // save for debug
                    // Clipboard.SetImage(blobToLook.Image.ToManagedImage());
                    return true;
                }
            }
            // Clipboard.SetImage(r);
            point = new Accord.Point();
            return false;
        }


        private double SortMostLikelyCursor(Blob x)
        {
            return Math.Abs(x.Area - 60);
        }

    }
}
