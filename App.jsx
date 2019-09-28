import "./App.css";
import "./services/autoLogInService.js";
import "react-toastify/dist/ReactToastify.css";
import logger from "./logger";
import React, { Component } from "react";
import logo from "./logo.svg";
import { withRouter } from "react-router-dom";
import { Container, Row } from "reactstrap";
import { ToastContainer } from "react-toastify";
import * as advertiserService from "../src/services/advertiserService";
import Cards from "./Cards";
const _logger = logger.extend("App");

class App extends Component {
  state = {
    payload: {
      shortTitle: "",
      title: "",
      content: "",
      metaDataId: "",
      shortDescription: "",
      createdBy: "",
      slug: "",
      statusId: "",
      entityTypeId: ""
    },
    advertisers: []
  };

  componentDidMount() {
    this.getAllCall();
  }
  getAllCall = () => {
    advertiserService.getAdvertisers().then(this.getSuccesss);
  };

  getSuccesss = data => {
    _logger(data);
    this.setState(() => ({
      ...this.state,
      advertisers: data.items
    }));
  };

  changeHandler = evt => {
    let key = evt.target.name;
    let val = evt.target.value;
    this.setState(() => ({
      ...this.state,
      payload: { ...this.state.payload, [key]: val }
    }));
  };

  clickHandler = e => {
    e.preventDefault();
    advertiserService
      .createAdvertiser(this.state.payload)
      .then(this.getAllCall);
  };

  editCard = advertiser => {
    this.setState(() => ({ payload: advertiser }));
  };

  mapAdvertisers = advertiser => {
    return (
      <Cards
        advertiser={advertiser}
        key={advertiser.id}
        editCard={this.editCard}
        deleteCard={this.deleteCard}
      />
    );
  };

  deleteCard = advertiser => {
    advertiserService.deleteAdvertiser(advertiser.id).then(this.getAllCall);
  };

  updateHandler = e => {
    e.preventDefault();
    advertiserService.editAdvertiser(this.state.payload).then(this.getAllCall);
  };

  render() {
    return (
      <React.Fragment>
        <ToastContainer />
        <Container>
          <Row className="justify-content-center">
            <img src={logo} className="App-logo" alt="logo" />
          </Row>
          <Row>
            <div className="card col-md-4 p-3">
              <form>
                <label>Short Title</label>
                <input
                  name="shortTitle"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  placeholder="Short Title"
                  value={this.state.payload.shortTitle}
                />
                <label>Title</label>
                <input
                  name="title"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.title}
                />
                <label>Short Description</label>
                <input
                  name="shortDescription"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.shortDescription}
                />
                <label>Content</label>
                <input
                  name="content"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.content}
                />
                <label>CreatedBy</label>
                <input
                  name="createdBy"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.createdBy}
                />
                <label>Slug</label>
                <input
                  name="slug"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.slug}
                />
                <label>EntityTypeId</label>
                <input
                  name="entityTypeId"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.entityTypeId}
                />
                <label>StatusId</label>
                <input
                  name="statusId"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.statusId}
                />
                <label>MetaDataId</label>
                <input
                  name="metaDataId"
                  type="text"
                  className="form-control"
                  onChange={this.changeHandler}
                  value={this.state.payload.metaDataId}
                />

                <button
                  className="btn btn-danger mt-2 mr-2"
                  onClick={this.clickHandler}
                >
                  Submit
                </button>
                <button
                  className="btn btn-primary mt-2"
                  onClick={this.updateHandler}
                >
                  Update
                </button>
              </form>
            </div>

            <div className="">
              <img
                src="https://d1vki863cvir6c.cloudfront.net/uploads/topic/image/147/Sabio_Logo_Wordmark_Square_Blue.gif"
                alt=""
              />
            </div>

            <div className="card p-5">
              {this.state.advertisers.map(this.mapAdvertisers)}
            </div>
          </Row>
          <br />
          <br />
          <br />
        </Container>
      </React.Fragment>
    );
  }
}

export default withRouter(App);
