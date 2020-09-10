import {
    CREATE_API_SERVICE, CREATE_API_FILTER,
    REQUEST_DATA, RECEIVE_DATA
} from './types';

const getUrl = (collection, filterProperties, searchProperties, ordenation, pagination, responseProperties) => {
    let endpoint = '';

    if (collection && collection !== '') {
        endpoint += collection;
    }

    let queryStringArray = [];

    if (filterProperties && Array.isArray(filterProperties) && filterProperties.length > 0) {
        queryStringArray.push(filterProperties.map(filterProperty => `${filterProperty.name}=${filterProperty.value}`).join('&'));
    }

    if (searchProperties) {
        let searchPropertiesArray = [];
        if (searchProperties.query && searchProperties.query !== '') {
            searchPropertiesArray.push(`query=${searchProperties.query}`);
        }
        if (searchProperties.strict) {
            searchPropertiesArray.push(`strict=${searchProperties.strict ? 'true' : 'false'}`);
        }
        if (searchProperties.phrase) {
            searchPropertiesArray.push(`phrase=${searchProperties.phrase ? 'true' : 'false'}`);
        }

        if (searchPropertiesArray.length > 0) {
            queryStringArray.push(searchPropertiesArray.join('&'));
        }
    }

    if (ordenation) {
        let ordenationArray = [];
        if (ordenation.orderBy && ordenation.orderBy !== '') {
            ordenationArray.push(`orderby=${ordenation.orderBy}`);
        }
        if (ordenation.order && ordenation.order !== '') {
            ordenationArray.push(`order=${ordenation.order}`);
        }

        if (ordenationArray.length > 0) {
            queryStringArray.push(ordenationArray.join('&'));
        }
    }

    if (pagination) {
        let paginationArray = [];
        if (pagination.number && pagination.number > 0) {
            paginationArray.push(`pagenumber=${pagination.number}`);
        }
        if (pagination.size && pagination.size > 0) {
            paginationArray.push(`pagesize=${pagination.size}`);
        }

        if (paginationArray.length > 0) {
            queryStringArray.push(paginationArray.join('&'));
        }
    }

    if (responseProperties && Array.isArray(responseProperties) && responseProperties.length > 0) {
        queryStringArray.push(responseProperties.map(responseProperty => `responseProperties=${responseProperty}`).join('&'));
    }

    if (queryStringArray && queryStringArray.length > 0) {
        endpoint += '?' + queryStringArray.join('&');
    }

    return endpoint;
};

const ApiWrapper = (id, collection, expires) => (dispatch) => {
    return {
        id: id,
        collection: collection,
        expires: expires,
        GetByFilter(filter) {
            let url = getUrl(
                this.collection,
                filter.filterProperties,
                filter.searchProperties,
                filter.ordenation,
                filter.pagination,
                filter.responseProperties
            );

            dispatch(HttpGet(url, this.expires));

            return url;
        },
        GetById(id) {
            let url = `${this.collection}/${id}`;

            dispatch(HttpGet(url, this.expires));

            return url;
        },
        Delete(id) {
            let url = `${this.collection}/${id}`;

            dispatch(HttpDelete(url));

            return url;
        },
        Patch(id, patchModel) {
            let url = `${this.collection}/${id}`;

            dispatch(HttpPatch(url, patchModel));

            return url;
        },
        Post(postModel) {
            let url = `${this.collection}`;

            dispatch(HttpPost(url, postModel));

            return url;
        },
        Put(id, putModel) {
            let url = `${this.collection}/${id}`;

            dispatch(HttpPut(url, putModel));

            return url;
        }
    }
};

const ApiFilter = (id) => {
    return {
        id: id,
        filterProperties: [],
        searchProperties: {},
        ordenation: {},
        pagination: {},
        responseProperties: [],
        clear() {
            this.filterProperties = [];
            this.searchProperties = { };
            this.ordenation = { };
            this.pagination = { };
            this.responseProperties = [];

            return this;
        },
        addFilter(propertyName, propertyValue) {
            this.filterProperties.push({ 'name': propertyName, 'value': propertyValue });

            return this;
        },
        setSearch(query, strict, phrase) {
            this.searchProperties = { 'query': query, 'strict': strict, 'phrase': phrase };

            return this;
        },
        setOrdenation(orderBy, order) {
            this.ordenation = { 'orderBy': orderBy, 'order': order };

            return this;
        },
        setPagination(size, number) {
            this.pagination = { 'size': size, 'number': number };

            return this;
        },
        addResponseProperties(propertyNames) {
            propertyNames.map(property => this.responseProperties.push(property));

            return this;
        },
        addResponseProperty(propertyName) {
            this.responseProperties.push(propertyName);

            return this;
        }
    }
};

const CreateApiService = (id, collection) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { apiServices } = ApiModelWrapperState;
    
    let filteredApiServices = apiServices.filter((apiService) => apiService.id === id);

    let apiServiceExists = filteredApiServices && filteredApiServices.length === 1;

    if (!apiServiceExists) {
        let minutesToExpire = 5 * 60 * 1000;
        let service = ApiWrapper(id, collection, minutesToExpire)(dispatch);
        dispatch({
            type: CREATE_API_SERVICE,
            payload: service
        });

        return service;
    } else {
        return filteredApiServices[0];
    }
};

const CreateApiFilter = (id) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { apiFilters } = ApiModelWrapperState;

    let filteredApiFilters = apiFilters.filter((apiFilter) => apiFilter.id === id);

    let apiFiltersExists = filteredApiFilters && filteredApiFilters.length === 1;

    if (!apiFiltersExists) {
        let filter = ApiFilter(id);
        dispatch({
            type: CREATE_API_FILTER,
            payload: filter
        });

        return filter;
    } else {
        return filteredApiFilters[0];
    }
};

const HttpGet = (endPoint, expires) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { requests } = ApiModelWrapperState;
    let lastRequest = requests[endPoint];
    let timeStamp = Date.now();
    if (lastRequest && lastRequest.timeStamp > timeStamp && lastRequest.endPoint === endPoint) {
        return;
    }

    fetch(endPoint)
        .then(response => response.json())
        .then(data => {
            let timeStamp = Date.now();
            timeStamp += expires;
            dispatch({ type: RECEIVE_DATA, payload: { endPoint: endPoint, timeStamp: timeStamp, response: data } });
        })
        .catch(error => console.error(error));

    timeStamp += expires;
    dispatch({ type: REQUEST_DATA, payload: { endPoint: endPoint, timeStamp: timeStamp, response: null } });
};

const HttpDelete = (endPoint) => (dispatch, getState) => {

};

const HttpPatch = (endPoint, patchedModel) => (dispatch, getState) => {

};

const HttpPost = (endPoint, postedModel) => (dispatch, getState) => {

};

const HttpPut = (endPoint, puttedModel) => (dispatch, getState) => {

};

export {
    CreateApiService,
    CreateApiFilter
};