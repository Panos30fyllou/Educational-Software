import { Question } from "./question";

export class Test {
    testId: number;
    chapter: string;
    questions: Question[];

    constructor() {
        this.testId = 0;
        this.chapter =""
        this.questions = [];
    }
}