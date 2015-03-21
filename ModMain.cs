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
        static string locker = "";
        public override void OnLevelLoaded(LoadMode mode)
        {
            ChirpLogger.ChirpLog.Debug("hmmm something");

            ChirpLogger.ChirpLog.Info("loaded");
            InceptorInterceptor.Add("System.Void IndustrialBuildingAI::GetPollutionRates(System.Int32,System.Int32&,System.Int32&)", new InceptorInterceptor.Interceptor((@this, name, parms) =>
            {
                //note: chirplogger is apparently broken when using from different threads or in some way can not handle this and will silently fail to log anything
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--begin--");
                int i=0;
                foreach (var p in parms)
                {
                    sb.AppendFormat("parms[{0}] = {1}\r\n", i, p == null ? "null" : p.ToString());
                    i+=1;
                }
                sb.AppendLine("--end--");
                lock(locker)
                {
                    File.AppendAllText("C:\\dev\\debug.txt", sb.ToString());
                }
                //groundpollution is 1
                parms[1] = 0;
                parms[2] = 10; //noise pollution
                return new object(); //return an object to tell the intercepted method to return immediately after this (return null to tell it to continue through with the body of the method
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
