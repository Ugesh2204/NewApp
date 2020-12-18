
// add the responsive classes after page initialization
window.onload = function () {
    $('.fc-toolbar.fc-header-toolbar').addClass('row col-lg-12');
};

// add the responsive classes when navigating with calendar buttons
$(document).on('click', '.fc-button', function(e) {
    $('.fc-toolbar.fc-header-toolbar').addClass('row col-lg-12');
});



// document.addEventListener('DOMContentLoaded', function() {
//   var calendarEl = document.getElementById('calendar');

//   var calendar = new FullCalendar.Calendar(calendarEl, {
//     headerToolbar: {
//       left: 'prev,next today',
//       center: 'title',
//       right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
//     },
//     initialDate: new Date(),
//     navLinks: true, // can click day/week names to navigate views
//     businessHours: true, // display business hours
//     editable: true,
//     selectable: true,
//     events: [
//     //   {
//     //     title: 'Barbel',
//     //     start: '2020-08-28T9:00:00',
//     //     constraint: 'businessHours'
//     //   },
//     //   {
//     //     title: 'Zumba',
//     //     start: '2020-08-27T9:30:00',
//     //     constraint: 'availableForMeeting', // defined below
//     //     color: '#257e4a'
//     //   },
//     //   {
//     //     title: 'Conference',
//     //     start: '2020-06-18',
//     //     end: '2020-06-20'
//     //   },
//     //   {
//     //     title: 'Party',
//     //     start: '2020-06-29T20:00:00'
//     //   },

//       {
//         title: 'Zumba',
//         start: '2020-08-27T09:00:00',
//         end: '2020-08-20T010:00:00',
//         color: '#257e4a'
//       },


//       {
//         title: 'Yoga',
//         start: '2020-08-27T010:15:00',
       
//         color: '#257e4a'
//       },

//       // areas where "Meeting" must be dropped
//     //   {
//     //     groupId: 'availableForMeeting',
//     //     start: '2020-06-11T10:00:00',
//     //     end: '2020-06-11T16:00:00',
//     //     display: 'background'
//     //   },
//     //   {
//     //     groupId: 'availableForMeeting',
//     //     start: '2020-06-13T10:00:00',
//     //     end: '2020-06-13T16:00:00',
//     //     display: 'background'
//     //   },

//       // red areas where no events can be dropped
//     //   {
//     //     start: '2020-06-24',
//     //     end: '2020-06-28',
//     //     overlap: false,
//     //     display: 'background',
//     //     color: '#ff9f89'
//     //   },
//     //   {
//     //     start: '2020-06-06',
//     //     end: '2020-06-08',
//     //     overlap: false,
//     //     display: 'background',
//     //     color: '#ff9f89'
//     //   }
//     ]
//   });

//   calendar.render();
// });

document.addEventListener('DOMContentLoaded', function() {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
      initialDate: new Date(),
      initialView: 'timeGridWeek',
      headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
      },
      height: 'auto',
      navLinks: true, // can click day/week names to navigate views
      editable: true,
      selectable: true,
      selectMirror: true,
      nowIndicator: true,
      events: [
        {
          title: 'Long Event',
          start: '2020-06-07',
          end: '2020-06-10'
        },
        {
          groupId: 999,
          title: 'Repeating Event',
          start: '2020-06-09T16:00:00'
        },
        {
          groupId: 999,
          title: 'Repeating Event',
          start: '2020-06-16T16:00:00'
        },
        {
          title: 'Conference',
          start: '2020-06-11',
          end: '2020-06-13'
        },
        {
          title: 'Meeting',
          start: '2020-06-12T10:30:00',
          end: '2020-06-12T12:30:00'
        },
        {
          title: 'Lunch',
          start: '2020-06-12T12:00:00'
        },
        {
          title: 'Meeting',
          start: '2020-06-12T14:30:00'
        },
        {
          title: 'Happy Hour',
          start: '2020-06-12T17:30:00'
        },
        {
          title: 'Dinner',
          start: '2020-06-12T20:00:00'
        },
        {
          title: 'Birthday Party',
          start: '2020-06-13T07:00:00'
        },
        {
          title: 'Click for Google',
          url: 'http://google.com/',
          start: '2020-06-28'
        },

        {
            title: 'Yoga',
            start: '2020-08-27T10:30:00',
            end: '2020-08-27T12:30:00',
            rendering: 'background',
            color: '#ff9f89'
        },

        {
            title: 'Zumba',
            start: '2020-08-27T08:00:00',
            end: '2020-08-27T09:30:00',
            rendering: 'background',
            color: '#f50'
          
        },

        {
            title: 'Barbel',
            start: '2020-08-27T10:45:00',
            end: '2020-08-27T11:30:00',
            rendering: 'background',
            color: '#f50'
          
        },

        {
            title: 'Zumba',
            start: '2020-08-28T08:00:00',
            end: '2020-08-28T09:30:00',
            rendering: 'background',
            color: '#f50'
          
        },
      ]
    });

    calendar.render();
  });