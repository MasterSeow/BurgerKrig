mergeInto(LibraryManager.library, {

sendResultJsonString: function(str) {
		try {
			ReactUnityWebGL.sendResultJsonString(Pointer_stringify(str));
		} catch(err) {
			// for unity test enviroment so we wont run in an fucing error
			console.log(Pointer_stringify(str)); // at least we log the provided string
			console.error(err);
		}
		
    }
});