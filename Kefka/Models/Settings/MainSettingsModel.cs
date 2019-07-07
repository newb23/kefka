using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Kefka.Commands;
using Kefka.Properties;
using Kefka.Utilities;
using Kefka.ViewModels;
using Newtonsoft.Json;
using Color = System.Drawing.Color;

namespace Kefka.Models
{
    public class MainSettingsModel : BaseModel
    {
        private static MainSettingsModel _instance;
        public static MainSettingsModel Instance => _instance ?? (_instance = new MainSettingsModel());

        private MainSettingsModel() : base(CharacterSettingsDirectory + "/Kefka/Main_Settings.json")
        {
        }

#pragma warning disable 67

        public static event EventHandler PropertyUpdate;

#pragma warning restore 67

        private bool _useToggleOverlay,
            _usePositionalOverlay,
            _autoCommenceDuty,
            _autoDutyNotify,
            _useHpPotions,
            _castorQueue,
            _randomizeLogColor,
            _destroyTarget,
            _ignoreTargetDoTs,
            _useEnemyOverlay,
            _overrideLogColor,
            _readReportGuide,
            _dynamicTargetHp,
            _autoSprint,
            _useSafeNames,
            _useDebugLogging;

        private bool _showEnemyOverlayDps,
            _showEnemyOverlayTtd,
            _useGoadTarget,
            _showGoadTarget,
            _useManualGoad,
            _showManualGoad,
            _showToastMessages;

        private int _tarHpInt,
            _tarHpPct,
            _potionDelayAdjust,
            _lagAdjust,
            _autoCommenceDelay,
            _potionHpPct,
            _auraCheckAdjust,
            _gridRows,
            _timeToDeathLimit,
            _buffTimeToDeathLimit,
            _autoDutyVolume,
            _infoOverlaySize,
            _dotInstanceTier1HpPct,
            _dotInstanceTier2HpPct,
            _dotOverworldier1HpPct,
            _cdInstanceTier1HpPct,
            _cdInstanceTier2HpPct,
            _cdOverworldier1HpPct,
            _restHpPct,
            _restMpPct,
            _restTpPct,
            _goadTp;

        private double _positionOverlayWidth,
            _positionOverlayHeight,
            _positionOverlayX,
            _positionOverlayY,
            _toggleOverlayWidth,
            _toggleOverlayHeight,
            _toggleOverlayX,
            _toggleOverlayY,
            _mainWindowX,
            _mainWindowY,
            _enemyInfoX,
            _enemyInfoY,
            _toggleOverlayOpacity,
            _infoOverlayOpacity,
            _enemyInfoOverlayOpacity,
            _dotInstanceTier1HpAdvantage,
            _dotInstanceTier2HpAdvantage,
            _dotOverworldTier1HpAdvantage,
            _cdInstanceTier1HpAdvantage,
            _cdInstanceTier2HpAdvantage,
            _cdOverworldTier1HpAdvantage;

        private static Color _toastMessageColor, _logMessageColor;

        public static void SetMarker()
        {
            Logger.KefkaLog("Marker set at: {0}", DateTime.Now.ToString("h:mm:ss"));
        }

        public static void OpenColorPickerToast()
        {
            var colorDialog1 = new ColorDialog();

            var result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                _toastMessageColor = colorDialog1.Color;
            }
        }

        public static void OpenColorPickerLog()
        {
            var colorDialog1 = new ColorDialog();

            var result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                _logMessageColor = colorDialog1.Color;
            }
        }

        public System.Windows.Media.Color ToastColor(bool boolean)
        {
            var pickedColor = ToastMessageColor;
            var convertedToastColor =
                System.Windows.Media.Color.FromArgb(pickedColor.A, pickedColor.R, pickedColor.G, pickedColor.B);

            return boolean ? convertedToastColor : Colors.Red;
        }

        public System.Windows.Media.Color LogColor()
        {
            var pickedColor = LogMessageColor;
            var convertedToastColor =
                System.Windows.Media.Color.FromArgb(pickedColor.A, pickedColor.R, pickedColor.G, pickedColor.B);

            return convertedToastColor;
        }

        [JsonIgnore] public ICommand UncheckUseGoadTargetCommand => new DelegateCommand(UncheckUseGoadTarget);

        [JsonIgnore] public ICommand UncheckUseManualGoadCommand => new DelegateCommand(UncheckUseManualGoad);

        public void UncheckUseGoadTarget()
        {
            if (_useManualGoad)
                UseGoadTarget = false;
        }

        public void UncheckUseManualGoad()
        {
            if (UseGoadTarget)
                UseManualGoad = false;
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseGoadTarget
        {
            get => _useGoadTarget;
            set
            {
                _useGoadTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(100)]
        public double PositionOverlayWidth
        {
            get => _positionOverlayWidth;
            set
            {
                _positionOverlayWidth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public double PositionOverlayHeight
        {
            get => _positionOverlayHeight;
            set
            {
                _positionOverlayHeight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double PositionOverlayX
        {
            get => _positionOverlayX;
            set
            {
                _positionOverlayX = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double PositionOverlayY
        {
            get => _positionOverlayY;
            set
            {
                _positionOverlayY = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(100)]
        public double ToggleOverlayWidth
        {
            get => _toggleOverlayWidth;
            set
            {
                _toggleOverlayWidth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public double ToggleOverlayHeight
        {
            get => _toggleOverlayHeight;
            set
            {
                _toggleOverlayHeight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double ToggleOverlayX
        {
            get => _toggleOverlayX;
            set
            {
                _toggleOverlayX = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double ToggleOverlayY
        {
            get => _toggleOverlayY;
            set
            {
                _toggleOverlayY = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double MainWindowX
        {
            get => _mainWindowX;
            set
            {
                _mainWindowX = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double MainWindowY
        {
            get => _mainWindowY;
            set
            {
                _mainWindowY = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double EnemyInfoX
        {
            get => _enemyInfoX;
            set
            {
                _enemyInfoX = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public double EnemyInfoY
        {
            get => _enemyInfoY;
            set
            {
                _enemyInfoY = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseToggleOverlay
        {
            get => _useToggleOverlay;
            set
            {
                _useToggleOverlay = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePositionalOverlay
        {
            get => _usePositionalOverlay;
            set
            {
                _usePositionalOverlay = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(0)]
        public int TarHpInt
        {
            get => _tarHpInt;
            set
            {
                _tarHpInt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(0)]
        public int TarHpPct
        {
            get => _tarHpPct;
            set
            {
                _tarHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(0)]
        public int LagAdjust
        {
            get => _lagAdjust;
            set
            {
                _lagAdjust = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2500)]
        public int PotionDelayAdjust
        {
            get => _potionDelayAdjust;
            set
            {
                _potionDelayAdjust = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool AutoDutyNotify
        {
            get => _autoDutyNotify;
            set
            {
                _autoDutyNotify = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool AutoCommenceDuty
        {
            get => _autoCommenceDuty;
            set
            {
                _autoCommenceDuty = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int AutoCommenceDelay
        {
            get => _autoCommenceDelay;
            set
            {
                _autoCommenceDelay = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int PotionHpPct
        {
            get => _potionHpPct;
            set
            {
                _potionHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHpPotions
        {
            get => _useHpPotions;
            set
            {
                _useHpPotions = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseCastorQueue
        {
            get => _castorQueue;
            set
            {
                _castorQueue = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RandomizeLogColor
        {
            get => _randomizeLogColor;
            set
            {
                _randomizeLogColor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool DestroyTarget
        {
            get => _destroyTarget;
            set
            {
                _destroyTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool DestroyTargetLog
        {
            get => _destroyTarget;
            set
            {
                _destroyTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2500)]
        public int AuraCheckAdjust
        {
            get => _auraCheckAdjust;
            set
            {
                _auraCheckAdjust = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool IgnoreTargetDoTs
        {
            get => _ignoreTargetDoTs;
            set
            {
                _ignoreTargetDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(8)]
        public int GridRows
        {
            get => _gridRows;
            set
            {
                _gridRows = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int InfoOverlaySize
        {
            get => _infoOverlaySize;
            set
            {
                _infoOverlaySize = value;
                OverlayViewModel.Instance.FontSize = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEnemyOverlay
        {
            get => _useEnemyOverlay;
            set
            {
                _useEnemyOverlay = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public double ToggleOverlayOpacity
        {
            get => _toggleOverlayOpacity;
            set
            {
                _toggleOverlayOpacity = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public double InfoOverlayOpacity
        {
            get => _infoOverlayOpacity;
            set
            {
                _infoOverlayOpacity = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public double EnemyInfoOverlayOpacity
        {
            get => _enemyInfoOverlayOpacity;
            set
            {
                _enemyInfoOverlayOpacity = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(typeof(Color), "Lime")]
        // This needs to be public, else it will NOT be saved in the Settings json!
        public Color ToastMessageColor
        {
            get => _toastMessageColor;
            set
            {
                _toastMessageColor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        // This needs to be public, else it will NOT be saved in the Settings json!
        public Color LogMessageColor
        {
            get => _logMessageColor;
            set
            {
                _logMessageColor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(15)]
        public int TimeToDeathLimit
        {
            get => _timeToDeathLimit;
            set
            {
                _timeToDeathLimit = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int BuffTimeToDeathLimit
        {
            get => _buffTimeToDeathLimit;
            set
            {
                _buffTimeToDeathLimit = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool OverrideLogColor
        {
            get => _overrideLogColor;
            set
            {
                _overrideLogColor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(10)]
        public int AutoDutyVolume
        {
            get => _autoDutyVolume;
            set
            {
                _autoDutyVolume = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool ReadReportGuide
        {
            get => _readReportGuide;
            set
            {
                _readReportGuide = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int DotInstanceTier1HpPct
        {
            get => _dotInstanceTier1HpPct;
            set
            {
                _dotInstanceTier1HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2.00)]
        public double DotInstanceTier1HpAdvantage
        {
            get => _dotInstanceTier1HpAdvantage;
            set
            {
                _dotInstanceTier1HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int DotInstanceTier2HpPct
        {
            get => _dotInstanceTier2HpPct;
            set
            {
                _dotInstanceTier2HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4.00)]
        public double DotInstanceTier2HpAdvantage
        {
            get => _dotInstanceTier2HpAdvantage;
            set
            {
                _dotInstanceTier2HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int DotOverworldTier1HpPct
        {
            get => _dotOverworldier1HpPct;
            set
            {
                _dotOverworldier1HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2.00)]
        public double DotOverworldTier1HpAdvantage
        {
            get => _dotOverworldTier1HpAdvantage;
            set
            {
                _dotOverworldTier1HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int CdInstanceTier1HpPct
        {
            get => _cdInstanceTier1HpPct;
            set
            {
                _cdInstanceTier1HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2.00)]
        public double CdInstanceTier1HpAdvantage
        {
            get => _cdInstanceTier1HpAdvantage;
            set
            {
                _cdInstanceTier1HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int CdInstanceTier2HpPct
        {
            get => _cdInstanceTier2HpPct;
            set
            {
                _cdInstanceTier2HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4.00)]
        public double CdInstanceTier2HpAdvantage
        {
            get => _cdInstanceTier2HpAdvantage;
            set
            {
                _cdInstanceTier2HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int CdOverworldTier1HpPct
        {
            get => _cdOverworldier1HpPct;
            set
            {
                _cdOverworldier1HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2.00)]
        public double CdOverworldTier1HpAdvantage
        {
            get => _cdOverworldTier1HpAdvantage;
            set
            {
                _cdOverworldTier1HpAdvantage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool DynamicTargetHp
        {
            get => _dynamicTargetHp;
            set
            {
                _dynamicTargetHp = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnemyOverlayDps
        {
            get => _showEnemyOverlayDps;
            set
            {
                _showEnemyOverlayDps = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnemyOverlayTtd
        {
            get => _showEnemyOverlayTtd;
            set
            {
                _showEnemyOverlayTtd = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int RestHpPct
        {
            get => _restHpPct;
            set
            {
                _restHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int RestMpPct
        {
            get => _restMpPct;
            set
            {
                _restMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int RestTpPct
        {
            get => _restTpPct;
            set
            {
                _restTpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(400)]
        public int GoadTp
        {
            get => _goadTp;
            set
            {
                _goadTp = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualGoad
        {
            get => _useManualGoad;
            set
            {
                _useManualGoad = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGoadTarget
        {
            get => _showGoadTarget;
            set
            {
                _showGoadTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualGoad
        {
            get => _showManualGoad;
            set
            {
                _showManualGoad = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseAutoSprint
        {
            get => _autoSprint;
            set
            {
                _autoSprint = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseSafeNames
        {
            get => _useSafeNames;
            set
            {
                _useSafeNames = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowToastMessages
        {
            get => _showToastMessages;
            set
            {
                _showToastMessages = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseDebugLogging
        {
            get => _useDebugLogging;
            set
            {
                _useDebugLogging = value;
                OnPropertyChanged();
            }
        }

        private SelectedTheme _selectedTheme;

        [Setting]
        [DefaultValue(SelectedTheme.Pink)]
        public SelectedTheme Theme
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged();
            }
        }

        private string _currentRoutine;

        [Setting]
        [DefaultValue("")]
        public string CurrentRoutine
        {
            get => _currentRoutine;
            set
            {
                _currentRoutine = value;
                OnPropertyChanged();
            }
        }

        private HpPotionSelection _hpPotionSelection;

        [Setting]
        public HpPotionSelection SelectedPotion
        {
            get => _hpPotionSelection;
            set
            {
                _hpPotionSelection = value;
                OnPropertyChanged();
            }
        }
    }

    public enum SelectedTheme
    {
        Red,
        Green,
        Blue,
        Purple,
        Orange,
        Lime,
        Emerald,
        Teal,
        Cyan,
        Cobalt,
        Indigo,
        Violet,
        Pink,
        Magenta,
        Crimson,
        Amber,
        Yellow,
        Brown,
        Olive,
        Steel,
        Mauve,
        Taupe,
        Sienna
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum HpPotionSelection
    {
        [LocalizedDescription("Highest", typeof(Strings))]
        Highest,

        [LocalizedDescription("Lowest", typeof(Strings))]
        Lowest
    }
}