# How to add custom font in Xamarin.Forms Schedule (SfSchedule)

You can customize the month view with a custom font family by setting the FontFamily property to the following classes in Xamarin.Forms [SfSchedule](https://www.syncfusion.com/xamarin-ui-controls/xamarin-scheduler).
* [ViewHeaderStyle](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.ViewHeaderStyle.html) - You can change the appearance of ViewHeaderStyle by setting the DayFontFamily property of Schedule ViewHeaderStyle.
* [HeaderStyle](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.SfSchedule.html#Syncfusion_SfSchedule_XForms_SfSchedule_HeaderStyle) - You can change the appearance of HeaderStyle  by setting the FontFamily property of Schedule HeaderStyle.
* [MonthCellStyle](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.SfSchedule.html#Syncfusion_SfSchedule_XForms_SfSchedule_MonthCellStyle) - You can change the appearance of MonthCellStyle by setting the FontFamily property of Schedule MonthCellStyle.
* [MonthInlineViewStyle](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.MonthInlineViewStyle.html) - You can change the appearance of MonthInlineViewStyle by setting the FontFamily property of Schedule MonthInlineViewStyle.
* [WeekNumberStyle](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.WeekNumberStyle.html) - You can change the appearance of WeekNumber by setting the FontFamily property of Schedule WeekNumberStyle.

The following steps describe how to add a custom font file in the platform-specific projects.

**Android**

Add a custom font file in the Assets folder and set Build Action to AndroidAsset for the font file.

**iOS**

**STEP1:** Add a custom font file in the Resources folder and set Build Action to BundleResource. Then, ensure that the copy to output directory is set to AlwaysCopy.

**STEP2:** Add a custom font file name in the info.plist file as demonstrated in the following code sample.
```
<dict>……
        <key>UIAppFonts</key>
        <array>
            <string>Lobster-Regular.ttf</string>
        </array>
……</dict>
```
**UWP**

Add a custom font file in the Assets folder and set Build Action to Content.

**XAML**

Set custom font for schedule month view using font family properties.
```
<schedule:SfSchedule x:Name="Schedule"
                        DataSource="{Binding Meetings}"
                        ShowAppointmentsInline="True"
                        ScheduleView="MonthView">
 
    <schedule:SfSchedule.ViewHeaderStyle>
        <schedule:ViewHeaderStyle>
            <schedule:ViewHeaderStyle.DayFontFamily>
                <OnPlatform x:TypeArguments="x:String" iOS="Lobster-Regular" Android="Lobster-Regular.ttf" WinPhone="Assets/Lobster-Regular.ttf#Lobster" />
            </schedule:ViewHeaderStyle.DayFontFamily>
        </schedule:ViewHeaderStyle>
    </schedule:SfSchedule.ViewHeaderStyle>
 
    <schedule:SfSchedule.HeaderStyle>
        <schedule:HeaderStyle>
            <schedule:HeaderStyle.FontFamily>
                <OnPlatform x:TypeArguments="x:String" iOS="Lobster-Regular" Android="Lobster-Regular.ttf" WinPhone="Assets/Lobster-Regular.ttf#Lobster" />
            </schedule:HeaderStyle.FontFamily>
        </schedule:HeaderStyle>
    </schedule:SfSchedule.HeaderStyle>
 
    <schedule:SfSchedule.MonthCellStyle>
        <schedule:MonthViewCellStyle>
            <schedule:MonthViewCellStyle.FontFamily>
                <OnPlatform x:TypeArguments="x:String" iOS="Lobster-Regular" Android="Lobster-Regular.ttf" WinPhone="Assets/Lobster-Regular.ttf#Lobster" />
            </schedule:MonthViewCellStyle.FontFamily>
        </schedule:MonthViewCellStyle>
    </schedule:SfSchedule.MonthCellStyle>
 
    <schedule:SfSchedule.MonthViewSettings>
        <schedule:MonthViewSettings ShowWeekNumber="True">
            <schedule:MonthViewSettings.WeekNumberStyle>
                <schedule:WeekNumberStyle>
                    <schedule:WeekNumberStyle.FontFamily>
                        <OnPlatform x:TypeArguments="x:String" iOS="Lobster-Regular" Android="Lobster-Regular.ttf" WinPhone="Assets/Lobster-Regular.ttf#Lobster" />
                    </schedule:WeekNumberStyle.FontFamily>
                </schedule:WeekNumberStyle>
            </schedule:MonthViewSettings.WeekNumberStyle>
        </schedule:MonthViewSettings>
    </schedule:SfSchedule.MonthViewSettings>
 
    <schedule:SfSchedule.AppointmentMapping>
        <schedule:ScheduleAppointmentMapping
        ColorMapping="Color"
        EndTimeMapping="To"
        StartTimeMapping="From"
        SubjectMapping="EventName"
        />
    </schedule:SfSchedule.AppointmentMapping>
 
    <schedule:SfSchedule.BindingContext>
        <local:SchedulerViewModel/>
    </schedule:SfSchedule.BindingContext>
</schedule:SfSchedule>
```
**C#**

FontStyle for month inline view updated in OnMonthInlineLoaded event.
```
public class SchedulerPageBehavior : Behavior<ContentPage>
{
    private SfSchedule schedule;
    protected override void OnAttachedTo(ContentPage bindable)
    {
        base.OnAttachedTo(bindable);
        this.schedule = bindable.Content.FindByName<SfSchedule>("Schedule");
        this.WireEvents();
    }
 
    private void WireEvents()
    {
        this.schedule.OnMonthInlineLoadedEvent += Schedule_OnMonthInlineLoadedEvent;
    }
 
    private void Schedule_OnMonthInlineLoadedEvent(object sender, MonthInlineLoadedEventArgs args)
    {
        MonthInlineViewStyle monthInlineViewStyle = new MonthInlineViewStyle();
        monthInlineViewStyle.FontFamily = Device.OnPlatform("Lobster-Regular", "Lobster-Regular.ttf", "Assets/Lobster-Regular.ttf#Lobster");
        args.monthInlineViewStyle = monthInlineViewStyle;
    }
 
    protected override void OnDetachingFrom(ContentPage bindable)
    {
        base.OnDetachingFrom(bindable);
        this.UnWireEvents();
    }
 
    private void UnWireEvents()
    {
        this.schedule.OnMonthInlineLoadedEvent += Schedule_OnMonthInlineLoadedEvent;
    }
}
```

KB article - [How to add custom font in Xamarin.Forms Schedule (SfSchedule)](https://www.syncfusion.com/kb/12257/how-to-add-custom-font-in-xamarin-forms-schedule-sfschedule)