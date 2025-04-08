package main

import (
	"bufio"
	"encoding/json"
	"fmt"
	"os"
	"strings"
)

func main() {
	desafio1()
	desafio2()
	desafio3()
	desafio4()
	desafio5()
}

func desafio1() {
	INDICE := 13
	SOMA := 0
	K := 0

	for K < INDICE {
		K++
		SOMA += K
	}
	fmt.Println("Desafio 1 - Soma:", SOMA)
	print("\n")
}

func desafio2() {
	var numero int
	fmt.Print("Digite um número para verificar se pertence à sequência de Fibonacci: ")
	fmt.Scanln(&numero)

	a, b := 0, 1
	for b < numero {
		a, b = b, a+b
	}
	if b == numero || numero == 0 {
		fmt.Printf("Desafio 2: O número %d pertence à sequência de Fibonacci.\n", numero)
	} else {
		fmt.Printf("Desafio 2: O número %d NÃO pertence à sequência de Fibonacci.\n", numero)
	}
	print("\n")
}

type DiaFaturamento struct {
	Dia   int     `json:"dia"`
	Valor float64 `json:"valor"`
}

func desafio3() {
	arquivo, err := os.Open("diaFaturamento.json")
	if err != nil {
		fmt.Println("Erro ao abrir o arquivo:", err)
		return
	}
	defer arquivo.Close()

	var dados []DiaFaturamento
	decoder := json.NewDecoder(arquivo)
	err = decoder.Decode(&dados)
	if err != nil {
		fmt.Println("Erro ao decodificar o JSON:", err)
		return
	}

	var soma, menor, maior float64
	menor = -1
	var diasComFaturamento int

	for _, d := range dados {
		if d.Valor > 0 {
			soma += d.Valor
			diasComFaturamento++
			if menor == -1 || d.Valor < menor {
				menor = d.Valor
			}
			if d.Valor > maior {
				maior = d.Valor
			}
		}
	}

	media := soma / float64(diasComFaturamento)

	var diasAcimaDaMedia int
	for _, d := range dados {
		if d.Valor > media {
			diasAcimaDaMedia++
		}
	}

	fmt.Printf("Desafio 3:\n")
	fmt.Printf("Menor valor de faturamento: R$%.2f\n", menor)
	fmt.Printf("Maior valor de faturamento: R$%.2f\n", maior)
	fmt.Printf("Número de dias com faturamento acima da média: %d\n", diasAcimaDaMedia)
	print("\n")
}

func desafio4() {
	valores := map[string]float64{
		"SP":     67836.43,
		"RJ":     36678.66,
		"MG":     29229.88,
		"ES":     27165.48,
		"Outros": 19849.53,
	}

	var total float64
	for _, valor := range valores {
		total += valor
	}

	fmt.Println("Desafio 4 - Percentual de faturamento por estado:")
	for estado, valor := range valores {
		percentual := (valor / total) * 100
		fmt.Printf("%s: %.2f%%\n", estado, percentual)
	}
	print("\n")
}

func desafio5() {
	reader := bufio.NewReader(os.Stdin)
	fmt.Print("Digite uma palavra para inverter: ")
	palavra, _ := reader.ReadString('\n')
	palavra = strings.TrimSpace(palavra)

	invertida := ""
	for i := len(palavra) - 1; i >= 0; i-- {
		invertida += string(palavra[i])
	}

	fmt.Printf("Desafio 5: A palavra invertida é: %s\n", invertida)
}
