import WrapRequest from '../../WrapRequest';

export interface Sample {
    sampleID: number;
    description: string;
}

export const GetSamplesByFilterQuery = (filtro: WrapRequest<Sample>/*, dispatch*/) => {
    console.log('GetSamplesByFilterQuery');

    var data = [{
        sampleid: 1,
        description: 'sample 001'
    }, {
        sampleid: 2,
        description: 'sample 002'
    }];

    //dispatch({ type: 'RECEIVE_GETSAMPLESBYFILTER_ACTION', pageNumber: filtro.pageNumber, pageSize: filtro.pageSize, query: filtro.query, samples: data });
};