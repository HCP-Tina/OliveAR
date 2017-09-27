import React, { Component } from 'react';
import { FormGroup, Radio } from 'react-bootstrap';
import { shuffle } from 'lodash/fp';

import { defaultAnswer, rightAnswer, wrongAnswer } from './questions.css';

class Question extends Component {
  constructor(props) {
    super(props);

    this.answers = shuffle(this.props.answers);
  }

  state = { selected: null };

  selectAnswer = selected => {
    this.setState({ selected });
  };

  render() {
    const { id, question, correct } = this.props;
    return (
      <div>
        <p>{question}</p>
        <FormGroup>
          {this.answers &&
            this.answers.map(answer => {
              const answerHighlight =
                !this.state.selected || this.state.selected !== answer.id
                  ? defaultAnswer
                  : this.state.selected === correct ? rightAnswer : wrongAnswer;
              return (
                <div key={`answer-${id}-${answer.id}`}>
                  <Radio
                    name={`answer-${id}`}
                    inline
                    onChange={() => this.selectAnswer(answer.id)}
                  >
                    <span className={answerHighlight}>{answer.text}</span>
                  </Radio>
                </div>
              );
            })}
        </FormGroup>
      </div>
    );
  }
}

export default Question;
