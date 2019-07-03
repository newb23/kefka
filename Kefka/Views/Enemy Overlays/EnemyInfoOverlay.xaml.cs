using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;
using Kefka.Models;
using Kefka.Utilities;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Application;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Kefka.Views
{
    public partial class EnemyInfoOverlay
    {
        public EnemyInfoOverlay()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            EnemyOverlay.Stop();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && WindowCheck.ApplicationIsActivated())
            {
                var currentDeltaOpacity = e.Delta;
                if (currentDeltaOpacity == 120 && MainSettingsModel.Instance.EnemyInfoOverlayOpacity < 1)
                    MainSettingsModel.Instance.EnemyInfoOverlayOpacity = MainSettingsModel.Instance.EnemyInfoOverlayOpacity + 0.05;
                else
                {
                    MainSettingsModel.Instance.EnemyInfoOverlayOpacity = MainSettingsModel.Instance.EnemyInfoOverlayOpacity - 0.05;
                }

                if (MainSettingsModel.Instance.EnemyInfoOverlayOpacity <= 0)
                {
                    MainSettingsModel.Instance.EnemyInfoOverlayOpacity = .1;
                }

                if (MainSettingsModel.Instance.EnemyInfoOverlayOpacity >= 1)
                {
                    MainSettingsModel.Instance.EnemyInfoOverlayOpacity = 1;
                }
            }
        }
    }

    public static class EnemyOverlay
    {
        public static bool KefkaEnemyOverlayIsVisible;

        private static readonly KefkaEnemyOverlayUiComponent KefkaOverlayComponent = new KefkaEnemyOverlayUiComponent(true);

        public static void Start()
        {
            if (!Core.OverlayManager.IsActive)
            {
                Core.OverlayManager.Activate();
            }
            KefkaEnemyOverlayIsVisible = true;
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
            KefkaEnemyOverlayIsVisible = false;
        }
    }

    internal class KefkaEnemyOverlayUiComponent : OverlayUIComponent
    {
        public KefkaEnemyOverlayUiComponent(bool isHitTestable) : base(true)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new EnemyInfoOverlay();

                _control = new OverlayControl
                {
                    Name = "KefkaEnemyOverlay",
                    Content = overlayUc,
                    X = MainSettingsModel.Instance.EnemyInfoX,
                    Y = MainSettingsModel.Instance.EnemyInfoY,
                    AllowMoving = true
                };

                _control.MouseLeave += (sender, args) =>
                {
                    MainSettingsModel.Instance.EnemyInfoX = _control.X;
                    MainSettingsModel.Instance.EnemyInfoY = _control.Y;
                    MainSettingsModel.Instance.Save();
                };

                return _control;
            }
        }
    }
}