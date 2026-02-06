using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

public static class AutoTranslationManager
{
    private static Dictionary<string, string> _currentDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    private static string _translationsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations");

    public static Dictionary<string, string> CurrentDict => _currentDict;

    // =========================
    // Charger une langue
    // =========================
    public static void LoadLanguage(string lang)
    {
        string file = Path.Combine(_translationsPath, lang + ".json");
        if (!File.Exists(file))
            throw new FileNotFoundException($"Le fichier de traduction n'existe pas : {file}");

        string json = File.ReadAllText(file);
        _currentDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    }

    // =========================
    // Traduire un contrôle et ses enfants
    // =========================
    public static void Translate(Control ctrl)
    {
        if (ctrl == null || _currentDict == null)
            return;

        // Utiliser la clé stockée dans Tag ou initialiser Tag
        string key = ctrl.Tag as string;
        if (key == null)
        {
            key = ctrl.Text;
            ctrl.Tag = key; // on stocke la clé originale
        }

        if (_currentDict.ContainsKey(key))
            ctrl.Text = _currentDict[key];

        // Traduire enfants
        foreach (Control c in ctrl.Controls)
            Translate(c);

        // Traduire menu et onglets
        if (ctrl is MenuStrip menu)
            TranslateMenuItems(menu.Items);

        if (ctrl is TabControl tab)
            foreach (TabPage page in tab.TabPages)
            {
                string pageKey = page.Tag as string;
                if (pageKey == null)
                {
                    pageKey = page.Text;
                    page.Tag = pageKey;
                }

                if (_currentDict.ContainsKey(pageKey))
                    page.Text = _currentDict[pageKey];
            }
    }

    // Traduire les menus récursivement
    public static void TranslateMenuItems(ToolStripItemCollection items)
    {
        foreach (ToolStripItem item in items)
        {
            string key = item.Tag as string;
            if (key == null)
            {
                key = item.Text;
                item.Tag = key;
            }

            if (!string.IsNullOrEmpty(key) && _currentDict.ContainsKey(key))
                item.Text = _currentDict[key];

            if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                TranslateMenuItems(menuItem.DropDownItems);
        }
    }

    // Traduire tous les forms ouverts
    public static void TranslateAllOpenForms()
    {
        foreach (Form f in Application.OpenForms)
            Translate(f);
    }

    // =========================
    // Sauvegarde des traductions
    // =========================
    public static void SaveCurrentLanguage(string lang)
    {
        string file = Path.Combine(_translationsPath, lang + ".json");
        Dictionary<string, string> dict = File.Exists(file)
            ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file))
            : new Dictionary<string, string>();

        foreach (var kv in _currentDict)
            if (!dict.ContainsKey(kv.Key))
                dict[kv.Key] = kv.Value;

        File.WriteAllText(file, JsonConvert.SerializeObject(dict, Formatting.Indented));
    }


}
