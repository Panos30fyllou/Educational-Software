export class Question {
    questionId: number;
    description: string
    correctAnswerId: number;
    points: number;

    constructor() {
        this.questionId = 0
        this.description = ""
        this.correctAnswerId = 0
        this.points = 0
    }
}