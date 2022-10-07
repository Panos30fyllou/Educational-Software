export class TestResult {
    studentId: number
    date: Date
    wrongQuestionIds: number[]
    score: number
    startingChapterId: number
    endingChapterId: number

    constructor() {
        this.studentId = 0;
        this.date = new Date();
        this.wrongQuestionIds = []
        this.score = 0
        this.startingChapterId = 0
        this.endingChapterId = 0
    }
}