"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var WeatherForecasts = require("./ActionReducers/WeatherForecasts");
var Counter = require("./ActionReducers/Counter");
var Samples = require("./ActionReducers/Samples");
// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
exports.reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    getSamplesByFilter: Samples.reducer
};
//# sourceMappingURL=index.js.map