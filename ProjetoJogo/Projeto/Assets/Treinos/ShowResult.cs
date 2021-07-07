using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowResult : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI precision;
    public TextMeshProUGUI tde;
    public TextMeshProUGUI disparos;
    public TextMeshProUGUI eps;
    public TextMeshProUGUI tmee;

    // Start is called before the first frame update
    public void setValues(modelRelatorioGridShot dados)
    {
        score.text = dados.score.ToString() + "<size=14>PTS";
        precision.text = dados.precision.ToString("0.##") + "%";
        tde.text = dados.hits.ToString();
        disparos.text = dados.shots.ToString();
        eps.text = dados.kps.ToString();
        tmee.text = dados.ttk.ToString();
    }
}
