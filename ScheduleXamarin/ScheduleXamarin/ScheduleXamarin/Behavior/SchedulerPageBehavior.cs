using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleXamarin
{
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
}
