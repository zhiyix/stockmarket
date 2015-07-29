using System.Runtime.Serialization;
namespace Framework
{
    /// <summary>
    /// 简单指令前缀:_scmd_  (位置级1)
    /// 复合指令前缀:_ccmd_  (位置级1)  
    /// case模型接口前缀:_cmp_  特别注意内容必须是cmp的全名
    /// 
    /// 规则,一条指令只能有一个_scmd_或_ccmd_的指令节;而_scmd_不能包含其它指令节，_ccmd_则必须包含其它指令节.(注意:程序暂不提供指令节的法则检查，但如果不按照这个基本规则构造指令，那么对指令的解析将陷入混乱，整个指令系统也将变得混乱和失去应有的意义)
    /// </summary>
    [DataContract]
    public enum Command
    {
        #region 默认指令
        //单指令
        [EnumMember]
        _scmd_回传消息,
        [EnumMember]
        _scmd_显示回传消息,
        [EnumMember]
        _scmd_简单服务,
        [EnumMember]
        _scmd_sn赋值完毕,
        [EnumMember]
        _ccmd_title,
        //
        #endregion
        //
        #region 项目指
        //_cmp_题头的指令内容是“对象模型接口”的类名称
        //_cmp_pcm1,,
        [EnumMember]
        _cmp_pcm1,
        [EnumMember]
        _x_login,
        [EnumMember]
        _x_registry
        #endregion
    }
}