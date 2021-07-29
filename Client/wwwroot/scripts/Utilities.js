function my_function(message) {
	console.log("from utilities " + message);
}

function dotnetStaticInvocation() {
	DotNet.invokeMethodAsync("BlazorMoviesApp.Client", "GetCurrentCount")
		.then(result => { 
			console.log("count from javascript " + result);
		});

	//promise
}

function dotnetInstanceInvocation(dotnetHelper) {
	dotnetHelper.invokeMethodAsync("IncrementCount");
}