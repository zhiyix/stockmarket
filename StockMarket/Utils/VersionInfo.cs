using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace StockMarket.Utils
{
    public class VersionInfo
    {
        private String verInfo = "";
        public String VerInfo
        {
            get
            {
                return verInfo;
            }
        }

        public static string getVersionInfo()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            //如果是当前程序集
            //如果是其他文件
            //string filename = Application.StartupPath + "\\xxx.exe";
            //Assembly asm = Assembly.LoadFile(filename);
            AssemblyDescriptionAttribute asmdis =
                (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute));
            AssemblyCopyrightAttribute asmcpr =
                (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            AssemblyCompanyAttribute asmcpn =
                (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCompanyAttribute));
            string s = string.Format("{0}  {1}  {2} ", asmdis.Description, asmcpr.Copyright, asmcpn.Company);
            Console.WriteLine(s);
            return s;
        }
    }

    public class AssemblyInfoHelper
    {
        Type m_Type;
        public AssemblyInfoHelper(Type type)
        {
            this.m_Type = type;
            Assembly assembly = Assembly.GetAssembly(type);
            VersionInfo = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0] as AssemblyFileVersionAttribute;
            CompanyInfo = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0] as AssemblyCompanyAttribute;
            ProductInfo = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0] as AssemblyProductAttribute;
            TitleInfo = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute;
            CopyrightInfo = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute;
            DescriptionInfo = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute;
        }
        /// <summary>
        /// 版本信息
        /// </summary>
        public AssemblyFileVersionAttribute VersionInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 公司信息
        /// </summary>
        public AssemblyCompanyAttribute CompanyInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 产品信息
        /// </summary>
        public AssemblyProductAttribute ProductInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 标题信息
        /// </summary>
        public AssemblyTitleAttribute TitleInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 版权信息
        /// </summary>
        public AssemblyCopyrightAttribute CopyrightInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 描述信息
        /// </summary>
        public AssemblyDescriptionAttribute DescriptionInfo
        {
            get;
            private set;
        }

    }
}
