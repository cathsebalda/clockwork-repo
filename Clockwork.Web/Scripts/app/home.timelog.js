function GetTime() {
	url = '/TimeLog/Time';
	$.ajax({
		url: url,
		data: '',
		type: 'GET',
		cache: false,
		datatype: 'html',
		success: function (response) {
			GetListPartial();
			$('#modalTime').text(response.TimeString);
			$('#modalUtcTime').text(response.UTCTimeString);
			$('#modalTimezone').text(response.Timezone);
			$('#modalTimezoneContainer').hide();
			$('#timeLogDialog').modal('show');
		},
		error: function (request, status, error) { },
		complete: function () {

		}
	});
}

function GetTimeByTimezone() {
	var selectedTimezone = $('#timezone').find(':selected')[0].value;
	url = '/TimeLog/TimeByTimezone';
	$.ajax({
		url: url,
		data: { 'timezone': selectedTimezone },
		type: 'GET',
		cache: false,
		datatype: 'html',
		success: function (response) {
			GetListPartial();
			$('#modalTime').text(response.TimeString);
			$('#modalUtcTime').text(response.UTCTimeString);
			$('#modalTimezone').text(response.Timezone);
			$('#modalTimezoneContainer').show();
			$('#timeLogDialog').modal('show');
		},
		error: function (request, status, error) { },
		complete: function () {

		}
	});
}

function GetListPartial() {
	url = '/Home/TimeList';
	$.ajax({
		url: url,
		data: '',
		type: 'GET',
		cache: false,
		datatype: 'html',
		success: function (response) {
			$('#GridContainer').html('');
			$('#GridContainer').html(response);
		},
		error: function (request, status, error) { },
		complete: function () { }
	});
}
