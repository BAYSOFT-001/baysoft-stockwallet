"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// --------------------
// ACTION CREATORS
exports.actionCreators = {
    requestGetSamplesByFilter: function (pageNumber, pageSize, query) { return function (dispatch, getState) {
        var appState = getState();
        console.log(appState && appState.getSamplesByFilter && (pageNumber !== appState.getSamplesByFilter.pageNumber || pageSize !== appState.getSamplesByFilter.pageSize || query !== appState.getSamplesByFilter.query));
        if (appState && appState.getSamplesByFilter && (pageNumber !== appState.getSamplesByFilter.pageNumber || pageSize !== appState.getSamplesByFilter.pageSize || query !== appState.getSamplesByFilter.query)) {
            console.log('GetSamplesByFilter');
            var _query = query ? query : '';
            var _pageNumber = pageNumber ? pageNumber : 1;
            var _pageSize = pageSize ? pageSize : 10;
            fetch('https://localhost:4101/api/samples' + ("?query=" + _query + "&pageNumber=" + _pageNumber + "&pageSize=" + _pageSize + "&querystrict=true"))
                .then(function (response) { return response.json(); })
                .then(function (data) {
                dispatch({ type: 'RECEIVE_GETSAMPLESBYFILTER_ACTION', pageNumber: pageNumber, pageSize: pageSize, query: query, samples: data.data });
            });
            dispatch({ type: 'REQUEST_GETSAMPLESBYFILTER_ACTION', pageNumber: pageNumber, pageSize: pageSize, query: query });
        }
    }; }
};
// --------------------
// REDUCER
var unloadedState = { samples: [], isLoading: false };
exports.reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    var action = incomingAction;
    switch (action.type) {
        case 'REQUEST_GETSAMPLESBYFILTER_ACTION':
            return {
                pageNumber: action.pageNumber,
                pageSize: action.pageSize,
                query: action.query,
                samples: state.samples,
                isLoading: true
            };
        case 'RECEIVE_GETSAMPLESBYFILTER_ACTION':
            if (action.pageNumber === state.pageNumber && action.pageSize === state.pageSize && action.query === state.query) {
                return {
                    pageNumber: action.pageNumber,
                    pageSize: action.pageSize,
                    query: action.query,
                    samples: action.samples,
                    isLoading: false
                };
            }
            break;
    }
    return state;
};
//# sourceMappingURL=Samples.js.map