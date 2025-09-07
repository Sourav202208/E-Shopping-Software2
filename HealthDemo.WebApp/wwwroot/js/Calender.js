$(document).ready(function () {
    var events = [];
    var selectedEvent = null;
    FetchEventAndRenderCalendar();
    //<--Get Event-->
    function FetchEventAndRenderCalendar() {
        events = [];
        $.ajax({
            type: "GET",
            url: "/Calender/GetEvents",
            success: function (data) {

                $.each(data, function (i, v) {

                    events.push({
                        id: v.id,
                        title: v.title,
                        description: v.description,
                        start: moment(v.start),
                        end: v.end != null ? moment(v.end) : null,
                        color: v.isActive == false ? '#378006' : '#ff9999',
                        allDay: v.isFullDay
                    });
                })
                GenerateCalender(events);
            },
            error: function (error) {
                alert('failed');
            }
        })
    }

    //<--Generate Calendar-->
    function GenerateCalender(events) {

        $('#calender').fullCalendar('destroy');
        $('#calender').fullCalendar({
            height: parent,
            defaultDate: new Date(),
            timeFormat: 'h(:mm)a',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay,'
            },
            eventLimit: true,
            /*         eventcolor: '#378006',*/
            selectedEvent: true,
            events: events,
            select: addEvent,
            selectable: true,
            showNonCurrentDates: false,
            editable: true,
            eventClick: click,
        })
    }

    $('#txtStart,#txtEnd').datetimepicker({
        format: 'DD/MM/YYYY h :mm A',
    });
    //<--Display Event Data-->
    function click(event) {

        //Show popup
        $('#myModal').modal('show');
        $(' #hdID').val(event.id);
        $('#txtStart').val(event.start.format('DD/MM/YYYY HH:mm A')),
            $('#txtTitle').val(event.title),
            $('#chkIsFullDay').prop("checked", event.allDay || false),
            $('#chkIsFullDay').change();
        $('#txtEnd').val(event.end.format('DD/MM/YYYY HH:mm A')),
            $('#txtDescription').val(event.description)
        if ($('#IsAct').val(event.isActive == true)) {
            event.setProp('editable', false);
        }
    }

    $('#chkIsFullDay').change(function () {
        if ($(this).is(':checked')) {
            $('#divEndDate').hide();
        }
        else {
            $('#divEndDate').show();
        }
    });
    function openAddEditForm() {
        if (selectedEvent != null) {
            $('#hdID').val(selectedEvent.ID);
            $('#txtTitle').val(selectedEvent.title);
            $('#txtStart').val(selectedEvent.start.format('DD/MM/YYYY HH:mm A'));
            $('#chkIsFullDay').prop("checked", selectedEvent.allDay || false);
            $('#chkIsFullDay').change();
            $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format('DD/MM/YYYY HH:mm A') : '');
            $('#txtDescription').val(selectedEvent.description);

        }
        $('#myModal').modal('hide');
        $('#myModal').modal();
    }
    //<--Update Function-->
    $('#btnEdit').click(function (event) {

        var data = {
            Id: $('#hdID').val(),
            Title: $('#txtTitle').val(),
            start: $('#txtStart').val(),
            end: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val(),
            Description: $('#txtDescription').val(),
            IsFullDay: $('#chkIsFullDay').is(':checked')
        };
        SaveEvent(data);
    })

    // <--Delete Function-->
    $('#btnDelete').click(function () {

        var Id = $('#hdID').val();
        if (confirm("Are you sure you want to delete this event?")) {
            $.ajax({
                type: "POST",
                url: '/Calender/DeleteEvent',
                data: { 'Id': Id },
                success: function (data) {
                    if (data.status) {
                        //Refresh the calender
                        FetchEventAndRenderCalendar();
                        $('#myModal').modal('hide');

                    }
                },
                error: function () {
                    alert('Failed');
                }
            })
        }
    })
    //<--select-->
    function addEvent(start, end) {
        $('#myModal').modal('show');
        $('#txtStart').datetimepicker('date', start);
        $('#txtEnd').datetimepicker('date', end);
        selectedEvent = {
            ID: 0,
            Title: '',
            description: '',
            start: start,
            end: end,
            allDay: false,
            color: ''
        };
        openAddEditForm();
        $('#calendar').fullCalendar('unselect');
    }


    //Validation/
    $('#btnSave').click(function () {


        if ($('#txtSubject').val() == "") {
            alert('Subject required');
            return;
        }
        if ($('#txtStart').val() == "") {
            alert('Start date required');
            return;
        }
        if ($('#chkIsFullDay').is(':checked') == false && $('#txtEnd').val() == "") {
            alert('End date required');
            return;
        }
        else {
            var startDate = moment($('#txtStart').val(), "DD/MM/YYYY HH:mm A").toDate();
            var endDate = moment($('#txtEnd').val(), "DD/MM/YYYY HH:mm A").toDate();
            if (startDate > endDate) {
                alert('Invalid end date');
                return;
            }
        }
    })
    //<--Add function--> 
    $('#btnSave').click(function () {
        debugger;
        var start = $('#txtStart').val();
        var End = $('#txtEnd').val();
        var dateObject = new Date(Date.parse(start));

        var data = {
            Id: $('#hdID').val(),
            Title: $('#txtTitle').val(),
            Start: $('#txtStart').val(),
            StartDate: $('#txtStart').val(),
            EndDate: $('#txtEnd').val(),
            End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val(),
            Description: $('#txtDescription').val(),
            IsFullDay: $('#chkIsFullDay').is(':checked')
        }
        SaveEvent(data);
    })
    function SaveEvent(data) {

        $.ajax({
            type: "POST",
            url: '/Calender/SaveEvent',
            data: data,
            success: function (data) {

                //Refresh the calender
                FetchEventAndRenderCalendar();
                $('#myModal').modal('hide');
                alert('Data  saved');
            },
            error: function () {
                alert('Failed');
            }
        })
    }

    //// save to pass datetime values  Test Here Code ---
    //    $('#btnSavetext').click(function () {
    //        debugger;
    //        var datetimeModel = {
    //            date1: "",
    //            date2: "",
    //            // Add more datetime fields if needed
    //        };
    //        datetimeModel.date1 = $("#txtStart").val();
    //        datetimeModel.date2 = $("#txtEnd").val();

    //        var monStart = $('#txtStart').val();

    //        SaveEventtest(monStart);
    //    })

    //    function SaveEventtest(monStart) {
    //        $.ajax({
    //            url: "/Calender/ActionName", // Replace with the actual URL of your controller action
    //            type: "POST",
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: { sdssss: monStart },           
    //            success: function (response) {
    //                // Handle the server response here (if needed)
    //                console.log(response);
    //            },
    //            error: function (xhr, status, error) {
    //                // Handle errors (if any)
    //                console.log("Error:", error);
    //            }


    //        });
    //    }

    //})

})

    function SaveData() {
        let Model = {
            Title: $('#txtTitle').val(),
            Start: $('#txtStart').val(),
            End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val(),
            Description: $('#txtDescription').val(),
            IsFullDay: $('#chkIsFullDay').is(':checked')
        }
        $.ajax({
            url: '/Calender/SaveEvent',
            type: "POST",
            data: {GetData:Model},
            success: function (data) {

                //Refresh the calender
                FetchEventAndRenderCalendar();
                $('#myModal').modal('hide');
                alert('Data  saved');
            },
            error: function () {
                alert('Failed');
            }
        })
    }

