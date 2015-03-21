using ChirpLogger;
using Earlz.InceptorAssembly;
using ICities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestMod
{
    public class MyIUserMod: IUserMod
    {
        public string Name 
        {
            get { return "Your mod name here"; }
        }

        public string Description 
        {
            get { return "Your mod description here"; }
			
        }
    }
    public class InjectionPoint: LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            ChirpLogger.ChirpLog.Debug("hmmm something");

            ChirpLogger.ChirpLog.Info("loaded");
            InceptorInterceptor.Add("x", new InceptorInterceptor.Interceptor((@this, name, parms) =>
            {
                File.AppendAllText("C:\\dev\\debug.log", "uh huh");
                return null;
            }));

            base.OnLevelLoaded(mode);
        }
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
        }
    }
    public class TestLevel: LevelUpExtensionBase
    {
        public override ResidentialLevelUp OnCalculateResidentialLevelUp(ResidentialLevelUp levelUp, int averageEducation, int landValue, ushort buildingID, Service service, SubService subService, Level currentLevel)
        {
            ChirpLog.Debug("commerical levelup?");
            return base.OnCalculateResidentialLevelUp(levelUp, averageEducation, landValue, buildingID, service, subService, currentLevel);
        }
    }
}
