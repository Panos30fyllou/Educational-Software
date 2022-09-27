import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LessonComponent } from './lessons/lesson-detailed/lesson.component';
import { LessonsComponent } from './lessons/lessons-list/lessons.component';
import { LoginGuard } from './login.guard';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { TestComponent } from './tests/test-detailed/test.component';
import { TestsComponent } from './tests/tests-list/tests.component';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'test', component: TestComponent, canActivate: [LoginGuard]},
  { path: 'tests', component: TestsComponent, canActivate: [LoginGuard]},
  { path: 'lesson', component: LessonComponent, canActivate: [LoginGuard]},
  { path: 'lessons', component: LessonsComponent, canActivate: [LoginGuard]},
  { path: 'profile', component: ProfileComponent, canActivate: [LoginGuard]},
  { path: 'home', redirectTo: 'lessons' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
