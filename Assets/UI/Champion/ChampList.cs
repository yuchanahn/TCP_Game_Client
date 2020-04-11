using UnityEngine;

public class ChampList : YCNetObj<ChampList>, IUser
{
    private YCCE<champ_list_t> champ_list_self;

    [SerializeField] int user_id = -1;
    [SerializeField] public Transform view;

    internal champ_list_t Champ_list_self { get => champ_list_self.Value; set => champ_list_self.Value = value; }
    public champ_type_t ChampLast => Champ_list_self.champs[Champ_list_self.count - 1];

    public void Init(int user_id)
    {
        list[user_id] = this;
        champ_list_self.add_event(() =>
        {
            var cnt = GM.ChampSlot.GetComponentsInChildren<Transform>().Length;
            for (int i = 0; i < Champ_list_self.count - cnt; i++)
            {
                UIChampList.CreateImage(GM.ChampSlot, ChampDB.get(ChampLast.code).spr, view);
            }
        });
    }
}
