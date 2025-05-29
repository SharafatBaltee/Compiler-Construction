#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#define MAX 100

// Function to check if a string is a keyword or data type
int isKeywordOrDatatype(const char str[]) {
    const char *keywords[] = {"for", "while", "do", "int", "float", "char", "double", "static", "switch", "case"};
    for (int i = 0; i < 10; i++) {
        if (strcmp(str, keywords[i]) == 0)
            return 1; // It is a keyword or data type
    }
    return 0; // Not a keyword
}

int isOperator(char c) {
    const char operators[] = "+-*/=<>!&|";
    for (int i = 0; i < strlen(operators); i++) {
        if (c == operators[i])
            return 1;
    }
    return 0;
}

int main() {
    FILE *f1, *identifiersFile, *numbersFile, *operatorsFile, *keywordsFile, *headerFiles;
    char c, str[MAX];
    int num, lineno = 1, i = 0;

    f1 = fopen("lexicalanalyzer.cpp", "r");
    identifiersFile = fopen("identifiers.txt", "w");
    numbersFile = fopen("numbers.txt", "w");
    operatorsFile = fopen("operators.txt", "w");
    keywordsFile = fopen("keywords.txt", "w");
    headerFiles = fopen("headers.txt", "w");

    if (f1 == NULL) {
        printf("Error opening source file!\n");
        return 1;
    }

    while ((c = getc(f1)) != EOF) {
        if (isdigit(c)) {
            num = c - '0';
            c = getc(f1);
            while (isdigit(c)) {
                num = num * 10 + (c - '0');
                c = getc(f1);
            }
            fprintf(numbersFile, "%d\n", num);
            ungetc(c, f1);
        } else if (isalpha(c) || c == '_') {
            i = 0;
            str[i++] = c;
            c = getc(f1);
            while (isalnum(c) || c == '_') {
                str[i++] = c;
                c = getc(f1);
            }
            str[i] = '\0';
            ungetc(c, f1);

            if (isKeywordOrDatatype(str))
                fprintf(keywordsFile, "%s\n", str);
            else if (strstr(str, "#include") != NULL)
                fprintf(headerFiles, "%s\n", str);
            else
                fprintf(identifiersFile, "%s\n", str);
        } else if (isOperator(c)) {
            fprintf(operatorsFile, "%c\n", c);
        } else if (c == '\\') {
            c = getc(f1);
            if (c == 'n') lineno++;
        }
    }

    printf("Lexical analysis complete. Check the output files.\n");
    printf("Total number of lines: %d\n", lineno);

    fclose(f1);
    fclose(identifiersFile);
    fclose(numbersFile);
    fclose(operatorsFile);
    fclose(keywordsFile);
    fclose(headerFiles);

    return 0;
}