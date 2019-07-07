using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;
using Kefka.Properties;
using Kefka.Utilities;
using Newtonsoft.Json;

namespace Kefka.Models
{
    public class SabinSettingsModel : BaseModel
    {
        private static SabinSettingsModel _instance;
        public static SabinSettingsModel Instance => _instance ?? (_instance = new SabinSettingsModel());

        private SabinSettingsModel() : base(CharacterSettingsDirectory +
                                            "/Kefka/Routine Settings/Sabin/Sabin_Settings.json")
        {
        }

        private bool _useMantra,
            _useBuffs,
            _useHoldoGcDs,
            _useAoE,
            _useDpsPotion,
            _useMercyStroke,
            _useShoulderTackle,
            _useInterruptList,
            _useDoTs,
            _usePerfectBalance,
            _useHoldPositionals,
            _useOpener,
            _useArmoftheDestroyer,
            _useTornadoKick,
            _useManualInterrupt,
            _useOocFistsofWind,
            _useRiddleofEarth,
            _useBloodbath,
            _useElixirField,
            _useHowlingFist,
            _useFormShift,
            _useFeint,
            _useSecondWind;

        private bool _showMantra,
            _showBuffs,
            _showHoldoGcDs,
            _showAoE,
            _showDpsPotion,
            _showMercyStroke,
            _showShoulderTackle,
            _showInterruptList,
            _showDoTs,
            _showPerfectBalance,
            _showHoldPositionals,
            _showOpener,
            _showArmoftheDestroyer,
            _showTornadoKick,
            _showManualInterrupt,
            _showOocFistsofWind,
            _showRiddleofEarth,
            _showBloodbath,
            _showElixirField,
            _showHowlingFist,
            _showFormShift,
            _showFeint,
            _showSecondWind;

        private int _twinSnakesRfsh,
            _demolishRfsh,
            _touchofDeathRfsh,
            _dragonKickRfsh,
            _mobCount,
            _tpLimit,
            _foresightHpPct,
            _bloodbathHpPct,
            _shoulderTackleMinDistance,
            _secondWindHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public void UncheckUseInterruptList()
        {
            if (UseManualInterrupt)
                UseInterruptList = false;
        }

        public void UncheckUseManualInterrupt()
        {
            if (_useInterruptList)
                UseManualInterrupt = false;
        }

        [JsonIgnore] public ICommand ChangeFistModeCommand => new DelegateCommand(ChangeFistModeSelection);

        private void ChangeFistModeSelection()
        {
            switch (Fist)
            {
                case FistMode.Fire:
                    Fist = FistMode.Earth;
                    break;

                case FistMode.Earth:
                    Fist = FistMode.Wind;
                    break;

                case FistMode.Wind:
                    Fist = FistMode.None;
                    break;

                case FistMode.None:
                    Fist = FistMode.Fire;
                    break;
            }
        }

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMantra
        {
            get => _useMantra;
            set
            {
                _useMantra = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        {
            get => _useBuffs;
            set
            {
                _useBuffs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseHoldoGcDs
        {
            get => _useHoldoGcDs;
            set
            {
                _useHoldoGcDs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseAoE
        {
            get => _useAoE;
            set
            {
                _useAoE = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseDpsPotion
        {
            get => _useDpsPotion;
            set
            {
                _useDpsPotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMercyStroke
        {
            get => _useMercyStroke;
            set
            {
                _useMercyStroke = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseShoulderTackle
        {
            get => _useShoulderTackle;
            set
            {
                _useShoulderTackle = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseInterruptList
        {
            get => _useInterruptList;
            set
            {
                _useInterruptList = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(7000)]
        public int TwinSnakesRfsh
        {
            get => _twinSnakesRfsh;
            set
            {
                _twinSnakesRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(7000)]
        public int DemolishRfsh
        {
            get => _demolishRfsh;
            set
            {
                _demolishRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(7000)]
        public int TouchofDeathRfsh
        {
            get => _touchofDeathRfsh;
            set
            {
                _touchofDeathRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int DragonKickRfsh
        {
            get => _dragonKickRfsh;
            set
            {
                _dragonKickRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTornadoKick
        {
            get => _useTornadoKick;
            set
            {
                _useTornadoKick = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDoTs
        {
            get => _useDoTs;
            set
            {
                _useDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        {
            get => _useOpener;
            set
            {
                _useOpener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        {
            get => _mobCount;
            set
            {
                _mobCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseArmoftheDestroyer
        {
            get => _useArmoftheDestroyer;
            set
            {
                _useArmoftheDestroyer = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        {
            get => _tpLimit;
            set
            {
                _tpLimit = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePerfectBalance
        {
            get => _usePerfectBalance;
            set
            {
                _usePerfectBalance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseHoldPositionals
        {
            get => _useHoldPositionals;
            set
            {
                _useHoldPositionals = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        {
            get => _useManualInterrupt;
            set
            {
                _useManualInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMantra
        {
            get => _showMantra;
            set
            {
                _showMantra = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        {
            get => _showBuffs;
            set
            {
                _showBuffs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHoldoGcDs
        {
            get => _showHoldoGcDs;
            set
            {
                _showHoldoGcDs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAoE
        {
            get => _showAoE;
            set
            {
                _showAoE = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDpsPotion
        {
            get => _showDpsPotion;
            set
            {
                _showDpsPotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMercyStroke
        {
            get => _showMercyStroke;
            set
            {
                _showMercyStroke = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShoulderTackle
        {
            get => _showShoulderTackle;
            set
            {
                _showShoulderTackle = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        {
            get => _showInterruptList;
            set
            {
                _showInterruptList = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTornadoKick
        {
            get => _showTornadoKick;
            set
            {
                _showTornadoKick = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoTs
        {
            get => _showDoTs;
            set
            {
                _showDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        {
            get => _showOpener;
            set
            {
                _showOpener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowArmoftheDestroyer
        {
            get => _showArmoftheDestroyer;
            set
            {
                _showArmoftheDestroyer = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPerfectBalance
        {
            get => _showPerfectBalance;
            set
            {
                _showPerfectBalance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHoldPositionals
        {
            get => _showHoldPositionals;
            set
            {
                _showHoldPositionals = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        {
            get => _showManualInterrupt;
            set
            {
                _showManualInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseOocFistsofWind
        {
            get => _useOocFistsofWind;
            set
            {
                _useOocFistsofWind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOocFistsofWind
        {
            get => _showOocFistsofWind;
            set
            {
                _showOocFistsofWind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int ForesightHpPct
        {
            get => _foresightHpPct;
            set
            {
                _foresightHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int BloodbathHpPct
        {
            get => _bloodbathHpPct;
            set
            {
                _bloodbathHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRiddleofEarth
        {
            get => _useRiddleofEarth;
            set
            {
                _useRiddleofEarth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRiddleofEarth
        {
            get => _showRiddleofEarth;
            set
            {
                _showRiddleofEarth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBloodbath
        {
            get => _useBloodbath;
            set
            {
                _useBloodbath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBloodbath
        {
            get => _showBloodbath;
            set
            {
                _showBloodbath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseElixirField
        {
            get => _useElixirField;
            set
            {
                _useElixirField = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowElixerField
        {
            get => _showElixirField;
            set
            {
                _showElixirField = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHowlingFist
        {
            get => _useHowlingFist;
            set
            {
                _useHowlingFist = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHowlingFist
        {
            get => _showHowlingFist;
            set
            {
                _showHowlingFist = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFormShift
        {
            get => _useFormShift;
            set
            {
                _useFormShift = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFormShift
        {
            get => _showFormShift;
            set
            {
                _showFormShift = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(0)]
        public int ShoulderTackleMinDistance
        {
            get => _shoulderTackleMinDistance;
            set
            {
                _shoulderTackleMinDistance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeint
        {
            get => _useFeint;
            set
            {
                _useFeint = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFeint
        {
            get => _showFeint;
            set
            {
                _showFeint = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSecondWind
        {
            get => _useSecondWind;
            set
            {
                _useSecondWind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSecondWind
        {
            get => _showSecondWind;
            set
            {
                _showSecondWind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        {
            get => _secondWindHpPct;
            set
            {
                _secondWindHpPct = value;
                OnPropertyChanged();
            }
        }

        private FistMode _fistMode;

        [Setting]
        public FistMode Fist
        {
            get => _fistMode;
            set
            {
                _fistMode = value;
                OnPropertyChanged();
            }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FistMode
    {
        [LocalizedDescription("FistsofFire", typeof(Strings))]
        Fire,

        [LocalizedDescription("FistsofEarth", typeof(Strings))]
        Earth,

        [LocalizedDescription("FistsofWind", typeof(Strings))]
        Wind,

        [LocalizedDescription("None", typeof(Strings))]
        None
    }
}