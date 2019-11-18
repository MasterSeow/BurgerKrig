mergeInto(LibraryManager.library, {

sendResultJsonString: function(str) {
		ReactUnityWebGL.sendResultJsonString(Pointer_stringify(str));
    }
});