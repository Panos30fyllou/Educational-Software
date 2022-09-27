import { Question } from "./question";

export class Test {
    testId: number;
    questions: Question[];

    constructor() {
        this.testId = 0
        this.questions = [];
    }
}