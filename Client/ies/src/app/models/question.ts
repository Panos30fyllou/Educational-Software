import { Answer } from "./answer";

export class Question {
    questionId: number;
    description: string;
    possibleAnswers: Answer[]
    correctAnswerId: number;
    points: number;

    constructor() {
        this.questionId = 0
        this.description = ""
        this.possibleAnswers = []
        this.correctAnswerId = 0
        this.points = 0
    }
}