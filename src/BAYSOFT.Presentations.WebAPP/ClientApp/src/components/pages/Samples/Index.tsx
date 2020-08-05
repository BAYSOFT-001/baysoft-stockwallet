import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { InputGroup, InputGroupAddon, Button, Input, Pagination, PaginationItem, PaginationLink } from 'reactstrap';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../../../store';
import * as GetSamplesByFilterState from '../../../store/ActionReducers/Samples';

type IndexProps =
    GetSamplesByFilterState.GetSamplesByFilterState &
    typeof GetSamplesByFilterState.actionCreators &
    RouteComponentProps<{}>;

class Index extends React.PureComponent<IndexProps> {
    state = {
        query: "",
        pageNumber: 1,
        pageSize: 10
    }

    public componentDidMount() {
        console.log('Mount!');
        this.ensureDataFetched();
    }

    //public componentDidUpdate() {
    //    console.log('Update!');
    //    this.ensureDataFetched();
    //}

    handleQueryChange = (text: string) => {
        this.setState({ query: text });
    }
    handleSubmitQuery = () => {
        this.ensureDataFetched();
    }
    handlePagination = (number: number) => {
        console.log(number);
        this.setState({ pageNumber: number });
        this.ensureDataFetched();
    }
    public render() {
        let { query } = this.state;
        return (
            <React.Fragment>
                <div className="row">
                    <div className="col-10">
                        <h4>Samples</h4>
                        <h6 className="text-muted">List of samples</h6>
                    </div>
                    <div className="col-2">
                        <Link className="btn btn-primary btn-block" to="/samples/new">New</Link>
                    </div>
                </div>
                <hr />

                <div className="row mb-3">
                    <div className="col">
                        <InputGroup>
                            <Input value={query} onChange={(e) => this.handleQueryChange(e.target.value)} />
                            <InputGroupAddon addonType="append">
                                <Button color="secondary" onClick={() => this.handleSubmitQuery()}>Search!</Button>
                            </InputGroupAddon>
                        </InputGroup>
                    </div>
                </div>

                <div className="row">
                    <div className="col">
                        {this.renderTable()}
                    </div>
                </div>

                <div className="row">
                    <div className="col">
                        {this.renderPagenation(this.props.pageSize, this.props.pageNumber, this.props.resultCount, 5)}
                    </div>
                </div>

                <hr />

                <div className="row">
                    <div className="col">
                        <Link className="btn btn-link" to="/">Back</Link>
                    </div>
                </div>
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        console.log(this.state);

        const { pageNumber, pageSize, query } = this.state;

        this.props.requestGetSamplesByFilter(pageNumber, pageSize, query);
    }

    private renderTable() {
        return (
            <table className='table table-sm table-striped table-bordered' aria-labelledby="tabelLabel">
                <thead>
                    <tr className='bg-dark text-light'>
                        <th>#</th>
                        <th>Description</th>
                        <th style={{ width: 32 }}></th>
                        <th style={{ width: 32 }}></th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.samples.map((sample: GetSamplesByFilterState.Sample) =>
                        <tr key={sample.sampleID}>
                            <td>{sample.sampleID}</td>
                            <td>{sample.description}</td>
                            <td><Link className="btn-link" to={`/samples/edit/${sample.sampleID}`}>Edit</Link></td>
                            <td><Link className="btn-link" to={`/samples/delete/${sample.sampleID}`}>Delete</Link></td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }
    private renderPagenation(pageSize: number, pageNumber: number, totalItems: number, paginationRange: number) {
        let totalPages = (totalItems % pageSize == 0) ? (totalItems / pageSize) : (Math.floor(totalItems / pageSize) + 1);
        let pages = [];
        let rangeStart = pageNumber - paginationRange;
        let rangeEnd = pageNumber + paginationRange;
        for (var i = rangeStart; i <= rangeEnd; i++) {
            if (i > 0 && i <= totalPages) {
                pages.push(i);
            }
        }
        let firstActive = pageNumber === 1;
        let lastActive = pageNumber === totalPages;
        return (
            <Pagination size="sm" aria-label="Page navigation">
                <PaginationItem disabled={ firstActive }>
                    <PaginationLink first onClick={() => this.handlePagination(1)} />
                </PaginationItem>
                <PaginationItem disabled={ firstActive }>
                    <PaginationLink previous onClick={() => this.handlePagination(pageNumber - 1)} />
                </PaginationItem>

                {pages.map(number => <PaginationItem key={number} active={number == pageNumber}><PaginationLink onClick={()=>this.handlePagination(number)}>{number}</PaginationLink></PaginationItem>)}

                <PaginationItem disabled={ lastActive }>
                    <PaginationLink next onClick={() => this.handlePagination(pageNumber + 1)} />
                </PaginationItem>
                <PaginationItem disabled={ lastActive }>
                    <PaginationLink last onClick={() => this.handlePagination(totalPages)} />
                </PaginationItem>
            </Pagination>
        )
    }
};

export default connect(
    (state: ApplicationState) => state.getSamplesByFilter,
    GetSamplesByFilterState.actionCreators
)(Index as any);