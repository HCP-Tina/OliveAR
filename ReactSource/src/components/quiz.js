import React, { Component } from 'react';

import Question from './question';

import { small } from './quiz.css';

class Quiz extends Component {
  state = { questions: [], title: '', smallImage: '', backgroundImage: '' };

  async componentDidMount() {
    const url =
      process.env.NODE_ENV === 'production'
        ? '/OliveAR/quiz?quizid=1'
        : '/questions.json';
    const response = await fetch(url);
    const data = await response.json();
    const { questions, title, smallImage, backgroundImage } = data;
    this.setState({ questions, title, smallImage, backgroundImage });
  }

  render() {
    console.log(this.state.backgroundImage);
    return (
      <div
        className="container-fluid"
        style={{
          maxWidth: 1200,
          background: `url(${this.state
            .backgroundImage}) 275px 100px no-repeat`,
          paddingBottom: 100,
        }}
      >
        <div className="row">
          <div className="col-sm-2">
            {this.state.smallImage && (
              <img alt="" className={small} src={this.state.smallImage} />
            )}
          </div>
          <div className="col-sm-10">
            <h1>{this.state.title}</h1>
            {this.state.questions.map(question => (
              <Question key={question.id} {...question} />
            ))}
          </div>
        </div>
      </div>
    );
  }
}

export default Quiz;
