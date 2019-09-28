import React from "react";
import PropTypes from "prop-types";

const Cards = props => {
  const editHandler = () => {
    props.editCard(props.advertiser);
  };

  const deleteHandler = () => {
    props.deleteCard(props.advertiser);
  };
  return (
    <div className="card mb-5 p-2">
      <div>Short Title: {props.advertiser.shortTitle}</div>
      <div>Title: {props.advertiser.title}</div>
      <div>Short Description: {props.advertiser.shortDescription}</div>
      <div>Content: {props.advertiser.content}</div>
      <div>Created By: {props.advertiser.createdBy}</div>
      <div>
        <button className="btn btn-info mt-2 mr-2" onClick={editHandler}>
          EDIT
        </button>

        <button className="btn btn-success mt-2" onClick={deleteHandler}>
          DELETE
        </button>
      </div>
    </div>
  );
};

Cards.propTypes = {
  advertiser: PropTypes.shape({
    shortTitle: PropTypes.string,
    title: PropTypes.string,
    shortDescription: PropTypes.string,
    content: PropTypes.string,
    createdBy: PropTypes.number
  }),
  editCard: PropTypes.func,
  deleteCard: PropTypes.func
};

export default Cards;
