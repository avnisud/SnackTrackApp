using Newtonsoft.Json;
using System.IO;

namespace SnackAttAppTestFramework
{
    public class Constants
    {
        public static TestExecutionSeting ExecutionSetting = JsonConvert.DeserializeObject<TestExecutionSeting>(File.ReadAllText("TestExecutionSetting.json"));

        // Driver setting
        public static int DefaultSleepTime = 1000;
        public static string AppPackage = "com.something.snackattapp";
        public static string AppActivity = "com.something.snackattapp.MainActivity";
        public static readonly string LocalAndroidServerAddress = @"127.0.0.1:4723";

        //  App setting
        public static readonly string SubmitButtonId = "btn_submit";
        public static readonly string ListViewId = "lv_main";
        public static readonly string MenuItemCheckboxId = "cb_snack_selected";
        public static readonly string MenuItemDisplayTextId = "tv_snack_name";
        public static readonly string AddMenuItemButtonId = "menu_item_add";
        public static readonly string VeggieCheckboxId = "cb_filter_veggie";
        public static readonly string NonVeggieCheckboxId = "cb_filter_non_veggie";

        // Alert window
        public static readonly string AlertMessageId = "message";
        public static readonly string AlertMessageOkButtonId = "button1";
        public static readonly string AlertMessageText = "Select some tasty snacks and try again.";

        // Add menu item window
        public static readonly string MenuItemWindowsTitleId = "alertTitle";
        public static readonly string MenuItemWindowsTitleText = "Add a new snack";
        public static readonly string MenuItemWindowSnackType = "text1";
        public static readonly string MenuItemWindowTextClassName = "android.widget.EditText";
        public static readonly string MenuItemWindowCancelButtonId = "button2";
        public static readonly string MenuItemWindowSaveButtonId = "button1";
    }
}
