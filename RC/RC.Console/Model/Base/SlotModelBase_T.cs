namespace RC.Model
{
    public abstract class SlotModelBase<T> : SlotModelBase where T : PieceModelBase
    {
        public SlotModelBase()
            : base()
        {

        }

        public T Piece { get; set; }

        public override string ToString()
        {
            return this.Piece.ToString();
        }
    }
}
