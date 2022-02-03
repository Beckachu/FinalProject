using Xamarin.Forms;


using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;

namespace Practice
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Title = "Simple Circle";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += OnTapGestureRecognizerTapped;
            canvasView.GestureRecognizers.Add(tap);

            Content = canvasView;
            
        }

        bool showFill = true;

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
        //void OnCanvasViewTapped(object sender, EventArgs args)
        //{
            showFill ^= true;
            (sender as SKCanvasView).InvalidateSurface();
        }


        //protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
        //{
      //}
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Blue;
            
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
        }
    }
}