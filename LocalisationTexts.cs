using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LocalisationTexts : MonoBehaviour
{
    private string[] keys = {"settings", "restart", "sound", "moregames", "instructions", "rate", "contact",
	"highduplabel", "highdupnote",
	"highidlabel", "highidnote",
	"autoremlabel", "autoremnote",
	"newgame", "undo", "erase", "pencil", "hint", "easy", "medium", "hard", "expert",
	"loss"
		};

    private string[] english = {"settings", "restart", "Sound effects", "more games", "instructions", "rate us", "contact us",
	"Highlight Duplicates", "Highlight repeating numbers in each row, column and block.",
	"Highlight Identical Numbers", "When you select a cell with a number, the same numbers are highlighted.",
	"Auto Remove Notes", "When the number is placed, remove it from all notes in a row, column and block.",
	"New Game", "undo", "erase", "pencil", "hint", "easy", "medium", "hard", "expert",
	"* You will loss the current game"
		};

    private string[] french = { "paramètres", "recommencer", "Effets sonores", "plus de jeux", "instructions", "évaluez nous", "contactez nous",
	"Évidence les doublons", "Mettez en surbrillance les nombres récurrents dans chaque ligne, colonne et bloc.",
	"Évidence les numéros identiques", "Lorsque vous sélectionnez une cellule avec un numéro, les mêmes numéros sont mis en évidence.",
	"Supprimer automatiquement les notes", "Lorsque le numéro est placé, supprimez-le de toutes les notes d'une ligne, d'une colonne et d'un bloc.",
	"Nouveau Jeu", "défaire", "effacer", "noter", "conseil", "facile", "moyen", "difficile", "expert",
	"* Vous allez perdre le jeu en cours"
		};

    private string[] german = { "einstellungen", "neustarten", "Soundeffekte", "mehr spiele", "anweisung", "bewerten sie uns", "kontaktiere uns",
	"Markieren Sie Duplikate", "Markieren Sie sich wiederholende Zahlen in jeder Zeile, Spalte und Block.",
	"Markieren Sie identische Zahlen", "Wenn Sie eine Zelle mit einer Nummer auswählen, werden die gleichen Nummern hervorgehoben.",
	"Automatisch Notizen entfernen", "Wenn die Nummer platziert ist, entfernen Sie sie aus allen Notizen in einer Zeile, Spalte und Block.",
	"Neues Spiel", "ungeschehen machen", "löschen", "notieren", "Tipp", "einfach", "Mittel", "hart", "Experte",
	"* Sie werden das aktuelle Spiel verlieren"
		};

    private string[] italian = { "impostazioni", "ricominciare", "Effetti sonori", "più giochi", "istruzioni", "valutare", "contattaci",
	"Evidenzia i duplicati", "Evidenzia i numeri ripetuti in ogni riga, colonna e blocco.",
	"Evidenzia i numeri identici", "Quando si seleziona una cella con un numero, gli stessi numeri sono evidenziati.",
	"Rimuovi automaticamente note", "Quando viene inserito il numero, rimuovilo da tutte le note di una riga, colonna e blocco.",
	"Nuovo Gioco", "disfare", "cancellare", "notare", "suggerimento", "facile", "medio", "difficile", "esperto",
	"* Perderai il gioco attuale"
		};

    private string[] spanish = { "ajustes", "reiniciar", "Efectos sonoros", "más juegos", "instrucciones", "califícanos", "contáctenos",
	"Resalte duplicados", "Resalta la repetición de números en cada fila, columna y bloque.",
	"Resalta números idénticos", "Cuando selecciona una celda con un número, se resaltan los mismos números.",
	"Eliminar notas automáticamente", "Cuando se coloca el número, elimínelo de todas las notas de una fila, columna y bloque.",
	"Nuevo Juego", "deshacer", "borrar", "notar", "punta", "fácil", "medio", "difícil", "experto",
	"* Perderás el juego actual"
		};

    private string[] portugese = { "configurações", "reiniciar", "Efeitos sonoros", "mais jogos", "instruções", "nos avalie", "fale conosco",
	"Destacar duplicados", "Realce números repetidos em cada linha, coluna e bloco.",
	"Realçar números idênticos", "Quando você seleciona uma célula com um número, os mesmos números são destacados.",
	"Remover notas automaticamente", "Quando o número é colocado, remova-o de todas as notas em uma linha, coluna e bloco.",
	"Novo Jogo", "desfazer", "apagar", "anotar", "dica", "fácil", "médio", "difícil", "especialista",
	"* Você perderá o jogo atual"
		};
		

    private string[] texts;
    private Dictionary<string, string> mappedTexts = new Dictionary<string, string>();

    void Awake() {
        SystemLanguage language = Application.systemLanguage;

        switch (language)
        {
            case SystemLanguage.French:
                texts = french;
                break;
            case SystemLanguage.German:
                texts = german;
                break;
            case SystemLanguage.Italian:
                texts = italian;
                break;
            case SystemLanguage.Spanish:
                texts = spanish;
                break;
            case SystemLanguage.Portuguese:
                texts = portugese;
                break;				
            default:
                texts = english;
                break;
        }

        for (int i=0;i<keys.Length;i++) {
            mappedTexts.Add(keys[i], texts[i]);
        }
    }

    public string GetLocalisedText(string key) {
        return mappedTexts[key];
    }
}