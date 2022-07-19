using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeSoftware.Model
{
    class UserLoginDOffice
    {
        public string username { get; set; }
        public string password { get; set; }
        public int expiration { get; set; }
        public DeviceInfoDoffice deviceInfo { get; set; }
    }

    public class DeviceInfoDoffice
    {
        public string deviceId { get; set; }
        public string deviceType { get; set; }
        public string appId { get; set; }
        public string appVersion { get; set; }
    }

    public class UserInfo
    {
        public string State { get; set; }
        public string Message { get; set; }
        public UserDataDetail Data { get; set; }
    }

    public class UserDataDetail
    {
        public string accessToken { get; set; }
    }
     
    public class CalendarRequest
    {
        public string ID_DV { get; set; }
        public string TU_NGAY { get; set; }
        public string DEN_NGAY { get; set; }
        public string LOAI_LICH { get; set; }
        public string TINH_TRANG { get; set; }
        public int ID_PB_DK { get; set; }
        public int ID_NV_DK { get; set; }
        public int HNTH { get; set; }
        public int MAY_CHIEU { get; set; }
        public string CHU_TRI { get; set; }
        public int ID_CHU_TRI { get; set; }
        public string THANH_PHAN { get; set; }
        public int ID_THANH_PHAN { get; set; }
        public string CHUAN_BI { get; set; }
        public int ID_CHUAN_BI { get; set; }
       
    }

    public class CalendarDetailInfo
    {
        public string State { get; set; }
        public string Message { get; set; }
        public List<CalendarData> Data { get; set; }
    }

    public class CalendarData
    {
        public string NOI_DUNG { get; set; }
        public string THOI_GIAN_BD { get; set; }
        public string THOI_GIAN_KT { get; set; }
        public string NGAY_HOP { get; set; }
        public string CHU_TRI { get; set; }
        public List<MeetingPreparation> CHUAN_BI { get; set; }
        public List<Participants> THANH_PHAN { get; set; }
        public RoomID ID_PHONG_HOP { get; set; }
        public string PHONG_HOP { get; set; }
        public string TINH_TRANG { get; set; }
    }

    public class RoomID
    {
        public string TEN_PHONG { get; set; }
    }

    public class Participants
    {
        public string TEN { get; set; }
    }

    public class MeetingPreparation
    {
        public string TEN { get; set; }
    }
    public class ProcessedCalendarData
    {
        public string NOI_DUNG { get; set; }
        public DateTime THOI_GIAN_BD { get; set; }
        public DateTime THOI_GIAN_KT { get; set; }
        public DateTime NGAY_HOP { get; set; }
        public string CHU_TRI { get; set; }
        public List<MeetingPreparation> CHUAN_BI { get; set; }
        public List<Participants> THANH_PHAN { get; set; }
        public RoomID ID_PHONG_HOP { get; set; }
        public string PHONG_HOP { get; set; }
        
    }
}
