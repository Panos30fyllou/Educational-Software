import { LessonListItem } from "./lesson-list-item";

export class Lesson extends LessonListItem {
    material: string;

    constructor() {
        super();
        this.material = "material";
    }
}