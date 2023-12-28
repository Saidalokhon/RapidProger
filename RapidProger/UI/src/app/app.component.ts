import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Question {
  id: number;
  title: string;
  content: string;
  type: questionType;
  answers: Answer[]
}

interface Answer {
  id: number;
  content: string;
  isCorrect: boolean;
  questionId: number;
}

enum questionType {
  Checkbox,
  Radio,
  OpenQuestion
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public questions: Question[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getQuestions();
  }

  getQuestions() {
    this.http.get<Question[]>('https://localhost:7035/api/questions').subscribe(
      (result) => {
        this.questions = result;
        console.error(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'UI';
}
