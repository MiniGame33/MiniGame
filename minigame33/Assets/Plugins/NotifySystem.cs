using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// 消息的类型  
//public enum NotifyType
//{
//    PLAYER_ON_HURT,
//    BLOCK_PLACE,
//}

// 消息事件类，使用中传递的信息  
public class NotifyEvent
{
    protected Dictionary<string, string> arguments;  //参数  
    protected string type;  //事件类型  
    protected System.Object sender;    //发送者  

    // bean函数  
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Dictionary<string, string> Params
    {
        get { return arguments; }
        set { arguments = value; }
    }

    public System.Object Sender
    {
        get { return sender; }
        set { sender = value; }
    }

    // 常用函数  
    public override string ToString()
    {
        return type + " [ " + ((sender == null) ? "null" : sender.ToString()) + " ] ";
    }

    public NotifyEvent Clone()
    {
        return new NotifyEvent(type, arguments, sender);
    }

    // 构造函数  
    public NotifyEvent(string type, System.Object sender)
    {
        Type = type;
        Sender = sender;
        if (arguments == null)
        {
            arguments = new Dictionary<string, string>();
        }
    }

    public NotifyEvent(string type, Dictionary<string, string> args, System.Object sender)
    {
        Type = type;
        arguments = args;
        Sender = sender;
        if (arguments == null)
        {
            arguments = new Dictionary<string, string>();
        }
    }
}

// 消息监听者，这是一个delegate，也就是一个函数，当事件触发时，对应注册的delegate就会触发  
public delegate void EventListenerDelegate(System.Object data);

// 消息中心  
public class NotifacitionCenter
{
    // 单例  
    private static NotifacitionCenter instance;
    private NotifacitionCenter() { }
    public static NotifacitionCenter getInstance()
    {
        if (instance == null)
        {
            instance = new NotifacitionCenter();
        }
        return instance;
    }

    // 成员变量  
    Dictionary<string, EventListenerDelegate> notifications = new Dictionary<string, EventListenerDelegate>(); // 所有的消息  


    // 注册监视  
    public void registerObserver(string type, EventListenerDelegate listener)
    {
        if (listener == null)
        {
            Debug.LogError("registerObserver: listener不能为空");
            return;
        }

        // 将新来的监听者加入调用链，这样只要调用Combine返回的监听者就会调用所有的监听者  
        Debug.Log("NotifacitionCenter: 添加监视" + type);

        EventListenerDelegate myListener = null;
        notifications.TryGetValue(type, out myListener);
        notifications[type] = (EventListenerDelegate)Delegate.Combine(myListener, listener);
    }

    // 移除监视  
    public void removeObserver(string type, EventListenerDelegate listener)
    {
        if (listener == null)
        {
            Debug.LogError("removeObserver: listener不能为空");
            return;
        }

        // 与添加的思路相同，只是这里是移除操作  
        Debug.Log("NotifacitionCenter: 移除监视" + type);
        notifications[type] = (EventListenerDelegate)Delegate.Remove(notifications[type], listener);
    }

    public void removeAllObservers()
    {
        notifications.Clear();
    }

    // 消息触发  
    public void postNotification(string type, System.Object sender, System.Object data = null)
    {
        EventListenerDelegate listenerDelegate;
        if (notifications.TryGetValue(type, out listenerDelegate))
        {
            try
            {
                // 执行调用所有的监听者  
                listenerDelegate(data);
            }
            catch (System.Exception e)
            {
                throw new Exception(string.Concat(new string[] { "Error dispatching event", type.ToString(), ": ", e.Message, " ", e.StackTrace }), e);
            }
        }
    }

}