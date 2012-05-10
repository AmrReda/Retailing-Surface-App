using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SurfaceRetailingApp.Controls.RiverContent
{
    /// <summary>
    /// Interaction logic for SmallItemPreview.xaml
    /// </summary>
    public partial class SmallItemPreview : UserControl
    {
        /// <summary>
        /// Private reference to a rotate transform used to orient this item.
        /// </summary>
        private RotateTransform _rotation;

        /// <summary>
        /// Private reference to a translate transform to position this item.
        /// </summary>
        private TranslateTransform _translation;

        public SmallItemPreview()
        {
            InitializeComponent();

            RenderTransformOrigin = new Point(.5, .5);

            _rotation = new RotateTransform();
            _translation = new TranslateTransform();
            RenderTransform = new TransformGroup
            {
                Children = new TransformCollection { _rotation, _translation }
            };

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                SizeChanged += (sender, e) =>
                {

                    UpdateOrientation();
                };
            }
        }

        private double x;
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        private double y;
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        private double vy;
        public double VY
        {
            get { return this.vy; }
            set { this.vy = value; }
        }

        private double vx;
        public double VX
        {
            get { return this.vx; }
            set { this.vx = value; }
        }


        #region Orientation

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public double Orientation
        {
            get { return (double)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Identifier for the Orientation dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(double), typeof(SmallItemPreview), new PropertyMetadata(0.0, (sender, e) => (sender as SmallItemPreview).UpdateOrientation()));

        /// <summary>
        /// Updates the orientation.
        /// </summary>
        private void UpdateOrientation()
        {
            _rotation.Angle = Orientation;
        }

        #endregion

    }
}
