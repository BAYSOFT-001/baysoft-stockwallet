import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { InputGroup, InputGroupAddon, Button, Input } from 'reactstrap';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../../../store';
import * as GetSamplesByFilterState from '../../../store/ActionReducers/Samples';

type IndexProps =
    GetSamplesByFilterState.GetSamplesByFilterState &
    typeof GetSamplesByFilterState.actionCreators &
    RouteComponentProps<{}>;

class Index extends React.PureComponent<IndexProps> {
    state = {
        txtQuery:  ""
    }

    public componentDidMount() {
        console.log('Mount!');
        this.ensureDataFetched();
    }

    //public componentDidUpdate() {
    //    console.log('Update!');
    //    this.ensureDataFetched();
    //}

    handleQueryChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ txtQuery: e.target.value });
    }
    handleSubmitQuery = (e: React.MouseEvent<HTMLButtonElement>) => {
        this.ensureDataFetched();
    }
    public render() {
        let { txtQuery } = this.state;
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
                            <Input value={ txtQuery } onChange={this.handleQueryChange} />
                            <InputGroupAddon addonType="append">
                                <Button color="secondary" onClick={this.handleSubmitQuery}>Search!</Button>
                            </InputGroupAddon>
                        </InputGroup>
                    </div>
                </div>

                <div className="row">
                    <div className="col">
                        {this.renderTable()}
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
        const pageNumber = 1;
        const pageSize = 10;
        const query = this.state.txtQuery;
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
};

export default connect(
    (state: ApplicationState) => state.getSamplesByFilter,
    GetSamplesByFilterState.actionCreators
)(Index as any);