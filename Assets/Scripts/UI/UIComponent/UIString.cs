using UnityEngine;

public class UIString: Singleton<UIString>
{
    public string language = "en";

    void Start(){
        language = PlayerPrefs.GetString("Language");
    }

    public string startBtnText
    {
        get 
        { 
            switch (language)
            {
                case "vn": return "Bắt đầu";
                default: return "Start";
            };
        }
    }

    public string languageTitle 
    {
        get 
        { 
            switch (language)
            {
                case "vn": return "Ngôn ngữ";
                default: return "Language";
            };
        }
    }

    public string vietnameseBtnText
    {
        get 
        { 
            switch (language)
            {
                case "vn": return "Tiếng Việt";
                default: return "Vietnamese";
            };
        }
    }

    public string englishBtnText
    {
        get 
        { 
            switch (language)
            {
                case "vn": return "Tiếng Anh";
                default: return "English";
            };
        }
    }

    public string newsTitle
    {
        get {
            switch (language)
            {
                case "vn": return "Bản tin";
                default: return "Update";
            };
        }
    }

    public string waiterText
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Chạm để tiếp tục";
                default: return "Tap to continue";
            };
        }
    }

    public string settingTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Cài đặt";
                default: return "Settings";
            };
        }
    }

    public string quitBtnText
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thoát game";
                default: return "Quit game";
            };
        }
    }

    public string upgradeBtnText
    {
        get
        {
            switch(language)
            {
                case "vn": return "Nâng Cấp";
                default: return "Upgrade";
            };
        }
    }

    public string upgradeTitleText
    {
        get
        {
            switch(language)
            {
                case "vn": return "Các nâng cấp";
                default: return "Upgrades";
            }
        }
    }

    public string profileBtnText 
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thông tin các nhân";
                default: return "Profile";
            }
        }
    }

    public string profileTitle 
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thông tin các nhân";
                default: return "Profile";
            }
        }
    }

    public string usernameTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Tên";
                default: return "Username";
            }
        }
    }

    public string saveBtnText
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Lưu";
                default: return "Save";
            }
        }
    }

    public string skillTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Kỹ năng";
                default : return "Skill";
            }
        }
    }
    public string skillDescTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Mô tả";
                default: return "Description";
            }
        }
    }

    public string enemyTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thông tin kẻ thù";
                default: return "Enemy information";
            }
        }
    }

    public string stageText 
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Màn";
                default: return "Stage";
            }
        }
    }

    public string towerTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thông tin tháp";
                default: return "Tower infromation";
            }
        }
    }

    public string championTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Danh sách tướng";
                default: return "Champion list";
            }
        }
    }

    public string statTitle
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Thông số";
                default: return "Stat";
            }
        }
    }

    public string championBtnText
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Tướng";
                default: return "Champion";
            }
        }
    }

    public string skinTitle
    {
        get 
        {
            return "skin";
        }
    }

    public string normalSkin
    {
        get
        {
            switch(language)
            {
                case "vn": return "Mặc định";
                default: return "Default";
            }
        }
    }

    public string summerSkin
    {
        get 
        {
            switch(language)
            {
                case "vn": return "Skin Mùa hè";
                default: return "Summer";
            }
        }
    }
    public string skinNewsTemplate
    {
        get
        {
            SkinSystem _skinController = SkinSystem.Instance;
            string skinName = UIString.Instance.summerSkin;
            if (_skinController.SkinType == SkinTypeEnum.DEFAULT){
                skinName = UIString.Instance.normalSkin;
            }
            else {
                skinName = UIString.Instance.summerSkin;
            }
            switch(language)
            {
                case "vn" : return $"Thông báo quan trọng về việc sử dụng trang phục {skinName}: \n\n"
                                    + "Kính gửi toàn thể cộng đồng, \n"
                                    + "Chúng tôi xin gửi đến mọi người một thông báo quan trọng vì đang bước vào mùa đặc biệt. \n"
                                    + $"Trong thời gian này, chúng ta sẽ sử dụng trang phục {skinName} để tạo thêm không khí lễ hội và niềm vui cho trò chơi.";
                default: return $"Important announcement regarding the use of costume {skinName}: \n\n"
                                    + "Dear community members, \n"
                                    + "We would like to inform you about an important announcement as we enter a special season. \n"
                                    + $"During this time, we will be using costume {skinName} to create a festive and joyful atmosphere in the game.";
            }
        }
    }
}