export class StudentLessonProgress{
    studentId: number;
    lessonId: number;
    completed: boolean;
    dateCompleted: Date | null;
    
    constructor() {
        this.studentId = 0;
        this.lessonId = 0;
        this.completed = false;
        this.dateCompleted = new Date();
    }
}