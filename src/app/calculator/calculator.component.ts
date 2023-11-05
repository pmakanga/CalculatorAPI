import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CalculatorService } from '../calculator.service';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css'],
})
export class CalculatorComponent implements OnInit {
  firstNumber: number = 0;
  secondNumber: number = 0;
  operator: string = "";
  selectedOperator: string = 'add';
  result: number | null = null;
  errorMessage: string | null = null;

  calculationHistory: any[] = [];

  constructor(
    private http: HttpClient, 
    private calculatorService: CalculatorService,
    private cdr: ChangeDetectorRef,
    private ngZone: NgZone) {}

    ngAfterContentChecked() {
      this.cdr.detectChanges();
    }

  ngOnInit(): void {
    this.loadCalculationHistory();
  }

  loadCalculationHistory() {
    this.calculatorService.getCalculationHistory().subscribe(
      (history) => {
        this.calculationHistory = history;
      },
      (error) => {
        console.error('Error loading calculation history:', error);
      }
    );
  }

  calculate() {
    const payload = {
      firstNumber: this.firstNumber,
      secondNumber: this.secondNumber,
      operator: this.selectedOperator
    };
  
    this.http
      .post(environment.apiUrl +"/"+ this.selectedOperator, payload)
      .subscribe(
        (response: any) => {
          this.result = response.result;
        },
        (error) => {
          if (error.status === 400) {
            this.ngZone.run(() => {
              this.result = null;
              this.errorMessage = 'Error! Please check your input.';
              setTimeout(() => {
                this.errorMessage = null; // Clear the error message after some time
              }, 5000); // Adjust the time as needed
            });
          } else {
            console.error('Error:', error);
          }
        }
      );
  }

  clearAndReload() {
    this.firstNumber = 0;
    this.secondNumber = 0;
    this.result = null;
    this.loadCalculationHistory();
  }

  private isValidInput(value: number): boolean {
    return value !== null && !isNaN(value);
  }
}
