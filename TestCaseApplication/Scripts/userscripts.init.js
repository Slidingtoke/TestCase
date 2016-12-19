requirejs.config({
    urlArgs: "bust=V1",
    baseUrl: '/Scripts',
    waitSeconds: 200,
    shim: {
    	"bootstrap": { "deps": ['jquery'] },
    	"validate": { "deps": ['jquery'] },
    	"usermodel": { "deps": ['jquery', 'knockout'] },
    	"todoentrymodel": { "deps": ['jquery', 'knockout'] },
        
    },
    paths: {
    	"jquery": "jquery-1.10.2.min",
    	"knockout": "knockout-3.4.0",
    	"validate": "jquery.validate.min",
    	"bootstrap": "bootstrap.min",
    	"usermodel": "UserScripts/usermodel",
    	"todoentrymodel": "UserScripts/todoentrymodel",
        //"User": "LandingPageScripts/AnnonseModel",
        //"GoogleAndFacebookTracking": "LandingPageScripts/GoogleAndFacebookTracking"
    }
});

requirejs(['UserScripts/user.viewmodel']);

