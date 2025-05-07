// modal.js
class CustomModal {
    show(title, content) {
        const modalHtml = `
        <div class="modal fade" id="customModal" tabindex="-1">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">${title}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="modal-body">
                        ${content}
                    </div>
                </div>
            </div>
        </div>`;

        document.body.insertAdjacentHTML('beforeend', modalHtml);
        const modal = new bootstrap.Modal(document.getElementById('customModal'));
        modal.show();

        // Remover modal da DOM ao fechar
        document.getElementById('customModal').addEventListener('hidden.bs.modal', () => {
            document.getElementById('customModal').remove();
        });
    }
}
