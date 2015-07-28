$(document).ready(function() {
	console.log('Auto Acting...');
	
	var token = '';
	var actionServerReady = false;
	var serverUrl = 'http://localhost:58341';

	var wireEvents = function(){
		var sendButtons = $(':input[data-pfaa]');
		sendButtons.each(function () {
			var jqBtn = $(this);
			if (jqBtn.attr('data-pfaa') === 'sendButton'){
				jqBtn.click(function(){
					if (actionServerReady && token.length > 0){
						var data = collectData();					
						sendData(data);
					} else {
						console.log('action server is not ready');
					}
				});			
			}
		});
	};
		
	
	var collectData = function(){
		var inputs = $(':input[data-pfaa]');
		var data = [];

		inputs.each(function (index, elem) {
			var jqElem = $(elem);
			if (jqElem.attr('data-pfaa') !== 'sendButton'){
				data.push({
					id: index+1,
					key: jqElem.attr('data-pfaa'),
					val: jqElem.val()
				});     
			}
		});		
		
		return data;
	};
	
	var sendData = function(data){
		var request = {
			token: token,
			subject: 'TEST',
			body: 'AAA AA'
		};
		console.log(request);
		$.post(serverUrl + '/api/letters', request, function (response) {
			console.log(response);
		}, 'json').error(function (req, status, error) {
			console.log(error);
		});
	};
	
	var getToken = function () {
		var url = serverUrl + '/api/tokens' + '?domain=' + location.host;
		
		$.get(url, function (response) {
			actionServerReady = true;
			token = response.Value;
			
		}).error(function (req, status, error) {
			actionServerReady = false;
			token = '';
		});

		

	};
	
	getToken();
	wireEvents();
});