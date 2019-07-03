using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;
using Kefka.Models;
using Kefka.Utilities;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Control = System.Windows.Forms.Control;

namespace Kefka.Views
{
    public partial class KefkaBoundInfoOverlay
    {
        public KefkaBoundInfoOverlay()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            BoundInfoOverlay.Stop();
            FormManager.DisablePositionalOverlay();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && WindowCheck.ApplicationIsActivated())
            {
                var currentDelta = e.Delta;
                if (currentDelta == 120)
                    MainSettingsModel.Instance.InfoOverlaySize = MainSettingsModel.Instance.InfoOverlaySize + 10;
                else
                {
                    MainSettingsModel.Instance.InfoOverlaySize = MainSettingsModel.Instance.InfoOverlaySize - 10;
                }
            }

            if (Control.ModifierKeys == Keys.Shift && WindowCheck.ApplicationIsActivated())
            {
                var currentDeltaOpacity = e.Delta;
                if (currentDeltaOpacity == 120 && MainSettingsModel.Instance.InfoOverlayOpacity < 1)
                    MainSettingsModel.Instance.InfoOverlayOpacity = MainSettingsModel.Instance.InfoOverlayOpacity + 0.05;
                else
                {
                    MainSettingsModel.Instance.InfoOverlayOpacity = MainSettingsModel.Instance.InfoOverlayOpacity - 0.05;
                }

                if (MainSettingsModel.Instance.InfoOverlayOpacity <= 0)
                {
                    MainSettingsModel.Instance.InfoOverlayOpacity = .1;
                }

                if (MainSettingsModel.Instance.InfoOverlayOpacity >= 1)
                {
                    MainSettingsModel.Instance.InfoOverlayOpacity = 1;
                }
            }
        }
    }

    public static class BoundInfoOverlay
    {
        public static bool KefkaBoundInfoOverlayIsVisible;

        private static readonly KefkaInfoOverlayUiComponent KefkaOverlayComponent = new KefkaInfoOverlayUiComponent(true);

        public static void Start()
        {
            if (!Core.OverlayManager.IsActive)
            {
                Core.OverlayManager.Activate();
            }
            KefkaBoundInfoOverlayIsVisible = true;
            Core.OverlayManager.AddUIComponent(KefkaOverlayComponent);
        }

        public static void Stop()
        {
            if (!Core.OverlayManager.IsActive)
                return;

            Core.OverlayManager.RemoveUIComponent(KefkaOverlayComponent);
            InterruptManager.ResetInterrupts();
            TankBusterManager.ResetTankBusters();
            FormManager.SaveFormInstances();
            KefkaBoundInfoOverlayIsVisible = false;
        }
    }

    internal class KefkaInfoOverlayUiComponent : OverlayUIComponent
    {
        public KefkaInfoOverlayUiComponent(bool isHitTestable) : base(true)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new KefkaBoundInfoOverlay();

                _control = new OverlayControl
                {
                    Name = "KefkaInfoOverlay",
                    Content = overlayUc,
                    X = MainSettingsModel.Instance.PositionOverlayX,
                    Y = MainSettingsModel.Instance.PositionOverlayY,
                    AllowMoving = true
                };

                _control.MouseLeave += (sender, args) =>
                {
                    MainSettingsModel.Instance.PositionOverlayX = _control.X;
                    MainSettingsModel.Instance.PositionOverlayY = _control.Y;
                    MainSettingsModel.Instance.Save();
                };

                return _control;
            }
        }
    }
}