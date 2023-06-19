using crud_cqrs_pattern_mediatr.Data;

namespace crud_cqrs_pattern_mediatr.Services;

public static class DbMirrorService
{
    public static void Sync(AppDbContextWrite contextWrite, AppDbContextRead contextRead)
    {
        contextRead.AddRange(contextWrite.Clientes);
        contextRead.SaveChanges();
    }
}
