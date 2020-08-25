const GenerateGetByFilter = (collection, filterProperties, searchProperties, ordenation, pagination, responseProperties) => {
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
        queryStringArray.push(searchProperties.join('&'));
    }

    if (ordenation) {
        let ordenationArray = [];
        if (ordernation.orderBy && ordenation.orderBy !== '') {
            ordenationArray.push(`orderby=${ordenation.orderBy}`);
        }
        if (ordenation.order && ordernation.order !== '') {
            ordenationArray.push(`order=${ordenation.order}`);
        }
        queryStringArray.push(ordenation.join('&'));
    }

    if (pagination) {
        let paginationArray = [];
        if (pagination.number && pagination.number > 0) {
            paginationArray.push(`pagenumber=${pagination.number}`);
        }
        if (pagination.size && pagination.size > 0) {
            paginationArray.push(`pagesize=${pagination.size}`);
        }
        queryStringArray.push(paginationArray.join('&'));
    }

    if (responseProperties && Array.isArray(responseProperties) && responseProperties.length > 0) {
        queryStringArray.push(responseProperties.map(responseProperty => `responseProperties=${responseProperty}`).join('&'));
    }
    
    if (queryStringArray && queryStringArray.length > 0) {
        endpoint += '?' + queryStringArray.join('&');
    }

    return endpoint;
};

export default {
    GenerateGetByFilter
}