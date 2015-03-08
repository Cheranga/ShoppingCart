require.config({
    baseUrl: "/Scripts/",
    paths: {
        app: "App",
        jquery: "/Scripts/Lib/jquery-1.10.2.min",
        bootstrap: '/Scripts/Lib/bootstrap.min',
        knockout: '/Scripts/Lib/knockout-3.2.0',
        komapping: '/Scripts/Lib/knockout.mapping-latest'
    },
    shim: {
        bootstrap: {
            deps: ['jquery']
        },
        komapping: {
            deps: ['knockout']
        }
    }
});